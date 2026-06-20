using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Ubicacion
{
    public class UbicacionResponseDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public int IdLocalidad { get; set; }
    }
}