using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Localidad
{
    public class LocalidadRequestDto
    {
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public int IdCiudad { get; set; }
    }
}
