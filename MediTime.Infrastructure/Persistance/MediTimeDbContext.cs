using MediTime.Domain.Entities; // Para encontrar a classe Medicamento
using Microsoft.EntityFrameworkCore;

namespace MediTime.Infrastructure.Persistence
{
    public class MediTimeDbContext : DbContext
    {
        // Este construtor permite que a Injeção de Dependência (no Program.cs)
        // configure o banco de dados (ex: a string de conexão)
        public MediTimeDbContext(DbContextOptions<MediTimeDbContext> options) : base(options)
        {
        }

        // Mapeia a entidade "Medicamento" para uma tabela "Medicamentos" no banco
        public DbSet<Medicamento> Medicamentos { get; set; }

        // Você pode adicionar mais DbSets aqui para outras entidades (ex: Lembretes)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você pode adicionar configurações avançadas (Fluent API)
            // Ex: modelBuilder.Entity<Medicamento>().Property(p => p.Nome).HasMaxLength(150);

            base.OnModelCreating(modelBuilder);
        }
    }
}