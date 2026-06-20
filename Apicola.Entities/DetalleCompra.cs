using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class DetalleCompra : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Compra))]
        public int IdCompra { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        #region Virtual
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
        #endregion
    }
}
