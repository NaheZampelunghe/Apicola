using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Fecha : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Colmenar))]
        public int IdColmenar { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }

        public virtual Colmenar Colmenar { get; set; }
    }
}
