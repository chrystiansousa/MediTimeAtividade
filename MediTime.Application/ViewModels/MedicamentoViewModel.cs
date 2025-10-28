using System.ComponentModel.DataAnnotations;

namespace MediTime.Application.ViewModels
{
    public class MedicamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string Dosagem { get; set; }
        public string? Forma { get; set; }
    }
}