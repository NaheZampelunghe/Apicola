using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Medicamento
{
    public class MedicamentoRequestDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
