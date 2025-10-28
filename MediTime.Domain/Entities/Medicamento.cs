using System.ComponentModel.DataAnnotations;

namespace MediTime.Domain.Entities
{
    public class Medicamento
    {
        // Chave Primária
        public int Id { get; set; }

        // --- Pegue estas propriedades do seu projeto antigo ---

        [Required(ErrorMessage = "O nome é obrigatório")] // Você precisará adicionar o using para isso
        [StringLength(100)]
        public string Nome { get; set; }

        public string? Descricao { get; set; } // O '?' permite que seja nulo

        [Required(ErrorMessage = "A dosagem é obrigatória")]
        public string Dosagem { get; set; } // Ex: "500mg", "10ml"

        public string? Forma { get; set; } // Ex: "Comprimido", "Líquido"

        // Adicione outras propriedades que você tinha (Ex: Estoque, Horario, etc.)
        // --- Fim da referência ---
    }
}