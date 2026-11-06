using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Ubicacion : IEntidad
    {
        public Ubicacion()
        {
            Colmenares = new HashSet<Colmenar>();
        }
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [ForeignKey(nameof(Localidad))]
        public int IdLocalidad { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual ICollection<Colmenar> Colmenares { get; set; }
    }
}
