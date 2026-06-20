using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Medicamento
{
    public class MedicamentoRequestDto
    {
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
