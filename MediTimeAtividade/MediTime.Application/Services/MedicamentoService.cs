using AutoMapper;
using MediTime.Application.Interfaces;
using MediTime.Application.ViewModels;
using MediTime.Domain.Entities; // Para a Entidade
using MediTime.Domain.Interfaces; // Para o Repositório

namespace MediTime.Application.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IMapper _mapper; // Injeção do AutoMapper

        public MedicamentoService(IMedicamentoRepository medicamentoRepository, IMapper mapper)
        {
            _medicamentoRepository = medicamentoRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(MedicamentoCreateViewModel model)
        {
            var medicamento = _mapper.Map<Medicamento>(model);
            await _medicamentoRepository.AddAsync(medicamento);
        }

        public async Task DeleteAsync(int id)
        {
            await _medicamentoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MedicamentoViewModel>> GetAllAsync()
        {
            var medicamentos = await _medicamentoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicamentoViewModel>>(medicamentos);
        }

        public async Task<MedicamentoViewModel?> GetByIdAsync(int id)
        {
            var medicamento = await _medicamentoRepository.GetByIdAsync(id);
            return _mapper.Map<MedicamentoViewModel?>(medicamento);
        }

        // --- INÍCIO DO NOVO MÉTODO (UPDATE) ---
        public async Task UpdateAsync(MedicamentoEditViewModel model)
        {
            // 1. Busca a entidade original no banco (IMPORTANTE para o EF)
            var medicamentoOriginal = await _medicamentoRepository.GetByIdAsync(model.Id);

            if (medicamentoOriginal != null)
            {
                // 2. Mapeia os dados do ViewModel (tela) para a entidade que veio do banco
                // O AutoMapper atualiza 'medicamentoOriginal' com os dados de 'model'
                _mapper.Map(model, medicamentoOriginal);
                
                // 3. Manda o repositório salvar a entidade atualizada
                await _medicamentoRepository.UpdateAsync(medicamentoOriginal);
            }
        }
        // --- FIM DO NOVO MÉTODO ---
    }
}