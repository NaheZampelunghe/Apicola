using Apicola.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apicola.Entities
{
    public class Localidad : IEntidad
    {
        public Localidad()
        {
            Ubicaciones = new HashSet<Ubicacion>();
        }
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [ForeignKey(nameof(Ciudad))]
        public int IdCiudad { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
    }
}
