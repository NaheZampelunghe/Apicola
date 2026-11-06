using Apicola.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Apicola.Entities
{
    public class Provincia : IEntidad
    {
        public Provincia()
        {
            Ciudades = new HashSet<Ciudad>();
        }
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        public virtual ICollection<Ciudad> Ciudades { get; set; }
    }
}
