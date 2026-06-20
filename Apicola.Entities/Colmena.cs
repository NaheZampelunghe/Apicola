using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Colmena : IEntidad
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Colmenar))]
        public int IdColmenar { get; set; }

        [ForeignKey(nameof(Duenio))]
        public int IdDuenio { get; set; }
        public bool Viva { get; set; }

        public virtual Colmenar Colmenar { get; set; }
        public virtual Duenio Duenio { get; set; }
    }
}
