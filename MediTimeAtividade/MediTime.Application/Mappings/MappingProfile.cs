using AutoMapper;
using MediTime.Application.ViewModels;
using MediTime.Domain.Entities;

namespace MediTime.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamentos existentes
            CreateMap<Medicamento, MedicamentoViewModel>();
            CreateMap<MedicamentoCreateViewModel, Medicamento>();
            
            // --- NOVOS MAPEAMENTOS PARA EDIT ---
            
            // De ViewModel (Edit) para Entidade (aplicando mudanças na entidade existente)
            CreateMap<MedicamentoEditViewModel, Medicamento>();
            
            // De Entidade para ViewModel (Edit) - (Usado para preencher o formulário)
            CreateMap<Medicamento, MedicamentoEditViewModel>(); 
        }
    }
}