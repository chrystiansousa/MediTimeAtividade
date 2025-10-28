// --- Adicione estes 'usings' no topo ---
using MediTime.Application.Interfaces;
using MediTime.Application.Mappings;
using MediTime.Application.Services;
using MediTime.Domain.Interfaces;
using MediTime.Infrastructure.Persistence;
using MediTime.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DO BANCO DE DADOS (EF Core) ---
// Pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configura o DbContext para usar o SQL Server
builder.Services.AddDbContext<MediTimeDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- 2. CONFIGURAÇÃO DA INJEÇÃO DE DEPENDÊNCIA (IoC) ---

// Repositórios (Infraestrutura)
// "Quando um Controller pedir 'IMedicamentoRepository', entregue uma instância de 'MedicamentoRepository'"
builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();

// Serviços (Aplicação)
// "Quando um Controller pedir 'IMedicamentoService', entregue uma instância de 'MedicamentoService'"
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();

// Configuração do AutoMapper
// Registra o perfil de mapeamento que criamos na camada de Aplicação
builder.Services.AddAutoMapper(typeof(MappingProfile)); 


// --- 3. CONFIGURAÇÃO PADRÃO DO MVC ---
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();