using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Fecha
{
    public class FechaResponseDto
    {
        public int Id { get; set; }
        public int IdColmenar { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }
    }
}