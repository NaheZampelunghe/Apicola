using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Colmenar
{
    public class ColmenarResponseDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public int CantidadColmenas { get; set; }
        public int IdUbicacion { get; set; }
    }
}