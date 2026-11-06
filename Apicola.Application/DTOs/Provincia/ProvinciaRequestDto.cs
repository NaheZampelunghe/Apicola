using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Provincia
{
    public class ProvinciaRequestDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
