using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Ubicacion
{
    public class UbicacionRequestDto
    {
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public int IdLocalidad { get; set; }
    }
}