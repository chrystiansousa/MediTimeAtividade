using System.ComponentModel.DataAnnotations;

namespace MediTime.Application.ViewModels
{
    public class MedicamentoCreateViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A dosagem é obrigatória")]
        public string Dosagem { get; set; }

        public string? Forma { get; set; }
    }
}