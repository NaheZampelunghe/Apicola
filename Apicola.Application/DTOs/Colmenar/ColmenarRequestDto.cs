using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Colmenar
{
    public class ColmenarRequestDto
    {
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public int UbicacionId { get; set; }
    }
}