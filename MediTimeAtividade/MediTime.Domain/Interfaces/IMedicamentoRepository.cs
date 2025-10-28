// Precisamos dizer onde a entidade "Medicamento" está
using MediTime.Domain.Entities; 

namespace MediTime.Domain.Interfaces
{
    public interface IMedicamentoRepository
    {
        // Métodos CRUD Assíncronos

        Task<Medicamento> GetByIdAsync(int id);
        Task<IEnumerable<Medicamento>> GetAllAsync();
        Task AddAsync(Medicamento medicamento);
        Task UpdateAsync(Medicamento medicamento);
        Task DeleteAsync(int id);
    }
}