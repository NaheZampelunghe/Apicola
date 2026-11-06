using Apicola.Application.DTOs.Colmena;
using System.Xml.Linq;

namespace Apicola.Application.DTOs.Colmena
{
    public class ColmenaResponseDto
    {
        public int Id { get; set; }
        public string Colmenar { get; set; } = null!;
        public string Duenio { get; set; } = null!;
        public bool Viva { get; set; }
        public int IdColmenar { get; set; }
        public int IdDuenio { get; set; }
    }
}
