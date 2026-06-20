using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Medicamento
{
    public class MedicamentoResponseDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
    }
}