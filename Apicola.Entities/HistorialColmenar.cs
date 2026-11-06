using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class HistorialColmenar : IEntidad
    {
        public int Id { get; set; }
        public bool Curado { get; set; }
        public bool Alimentado { get; set; }
        public int CantidadMuertas { get; set; }
        public DateTime FechaVisita { get; set; }
        [ForeignKey(nameof(Alimento))]
        public int? IdAlimento { get; set; }

        [ForeignKey(nameof(Medicamento))]
        public int? IdMedicamento { get; set; }

        [ForeignKey(nameof(Colmenar))]
        public int? IdColmenar { get; set; }

        #region Virtuals
        public virtual Colmenar? Colmenar { get; set; }
        public virtual Alimento? Alimento { get; set; }
        public virtual Medicamento? Medicamento { get; set; }
        #endregion
    }
}
