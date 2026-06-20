using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Curado_Alimentado : IEntidad
    {
        public int Id { get; set; }
        public bool Curado { get; set; }
        public bool Alimentado { get; set; }
        [ForeignKey(nameof(Fecha))]
        public int IdFechaVisita { get; set; }
        public int CantidadMuertas { get; set; }

        public virtual Fecha Fecha { get; set; }
    }
}
