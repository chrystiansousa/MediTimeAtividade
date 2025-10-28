using System.ComponentModel.DataAnnotations;

namespace MediTime.Application.ViewModels
{
    public class MedicamentoEditViewModel
    {
        [Required]
        public int Id { get; set; } // O Id é essencial para o Update

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A dosagem é obrigatória")]
        public string Dosagem { get; set; } = string.Empty;

        public string? Forma { get; set; }
    }
}