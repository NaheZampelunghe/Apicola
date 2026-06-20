using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Provincia
{
    public class ProvinciaRequestDto
    {
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
