using System.ComponentModel.DataAnnotations;

namespace Apicola.Application.DTOs.Fecha
{
    public class FechaRequestDto
    {
        public int IdColmenar { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }
    }
}