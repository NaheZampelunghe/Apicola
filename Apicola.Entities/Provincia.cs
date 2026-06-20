using Apicola.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Apicola.Entities
{
    public class Provincia : IEntidad
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
