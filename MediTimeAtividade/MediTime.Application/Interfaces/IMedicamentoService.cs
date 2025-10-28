using MediTime.Application.ViewModels; 

namespace MediTime.Application.Interfaces
{
    public interface IMedicamentoService
    {
        Task<IEnumerable<MedicamentoViewModel>> GetAllAsync();
        Task<MedicamentoViewModel?> GetByIdAsync(int id);
        Task CreateAsync(MedicamentoCreateViewModel model);

        // --- VERIFIQUE ESTA LINHA ---
        Task UpdateAsync(MedicamentoEditViewModel model); 
        // --- FIM DA VERIFICAÇÃO ---

        Task DeleteAsync(int id);
    }
}