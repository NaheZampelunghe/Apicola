using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Proveedor : IEntidad
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [StringLength(30)]
        public string Direccion { get; set; } = null!;
        public int CodPostal { get; set; }
        [ForeignKey(nameof(Localidad))]
        public int IdLocalidad { get; set; }
        public decimal Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
