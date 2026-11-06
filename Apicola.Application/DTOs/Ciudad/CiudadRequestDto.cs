using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Application.DTOs.Ciudad
{
    public class CiudadRequestDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string? Nombre { get; set; } = null!;

        public int IdProvincia { get; set; }

    }
}
