using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Producto : IEntidad
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public decimal Stock { get; set; }
        [ForeignKey(nameof(Categoria))]
        public int IdCategoria { get; set; }
        [ForeignKey(nameof(Proveedor))]
        public int IdProveedor { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
