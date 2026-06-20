using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Curado_Medicamento : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Curado))]
        public int IdCurado { get; set; }
        [ForeignKey(nameof(Medicamento))]
        public int IdMedicamento { get; set; }
        [ForeignKey(nameof(Alimento))]
        public int IdAlimento { get; set; }

        #region Virtual
        public virtual Curado_Alimentado Curado { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        public virtual Alimento Alimento { get; set; }
        #endregion
    }
}
