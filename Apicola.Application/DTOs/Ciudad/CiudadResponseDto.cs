using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apicola.Application.DTOs.Ciudad
{
    public class CiudadResponseDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [StringLength(30)]
        public string Provincia { get; set; } = null!;
        public int IdProvincia { get; set; }
    }
}
