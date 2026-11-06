using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Duenio
{
    public class DuenioRequestDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [StringLength(30)]
        public string Apellido { get; set; } = null!;
        [StringLength(30)]
        public string RENAPA { get; set; } = null!;
        public int IdLocalidad { get; set; }
    }
}