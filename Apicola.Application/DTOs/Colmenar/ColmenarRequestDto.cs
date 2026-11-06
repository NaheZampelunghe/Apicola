using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Colmenar
{
    public class ColmenarRequestDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public int UbicacionId { get; set; }
    }
}