using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apicola.Application.DTOs.Categoria
{
    public class CategoriaResponseDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [StringLength(30)]
        public string Descripcion { get; set; } = null!;
    }
}
