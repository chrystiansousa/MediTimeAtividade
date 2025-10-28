using MediTime.Domain.Entities;
using MediTime.Domain.Interfaces;
using MediTime.Infrastructure.Persistence; // Para encontrar o DbContext
using Microsoft.EntityFrameworkCore; // Para métodos como ToListAsync, FindAsync, etc.

namespace MediTime.Infrastructure.Repositories
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly MediTimeDbContext _context;

        // Pedimos o DbContext via Injeção de Dependência
        public MedicamentoRepository(MediTimeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medicamento medicamento)
        {
            await _context.Medicamentos.AddAsync(medicamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            // Retorna todos os medicamentos
            return await _context.Medicamentos.ToListAsync();
        }

        public async Task<Medicamento> GetByIdAsync(int id)
        {
            // Encontra um medicamento pela sua chave primária (Id)
            return await _context.Medicamentos.FindAsync(id);
        }

        public async Task UpdateAsync(Medicamento medicamento)
        {
            // Informa ao EF que a entidade foi modificada
            _context.Entry(medicamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}