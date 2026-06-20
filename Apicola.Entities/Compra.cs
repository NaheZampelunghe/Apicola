using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Compra : IEntidad
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Proveedor))]
        public int IdProveedor { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }
        public decimal Precio { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
