namespace Apicola.Application.DTOs.Colmena
{
    public class ColmenaRequestDto
    {
        public int Id { get; set; }
        public int IdColmenar { get; set; }
        public int IdDuenio { get; set; }
        public bool Viva { get; set; }
    }
}