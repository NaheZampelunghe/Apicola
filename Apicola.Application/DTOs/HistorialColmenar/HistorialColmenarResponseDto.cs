namespace Apicola.Application.DTOs.CuradoAlimentado
{
    public class HistorialColmenarResponseDto
    {
        public int Id { get; set; }
        public bool Curado { get; set; }
        public bool Alimentado { get; set; }
        public DateTime FechaVisita { get; set; }
        public int CantidadMuertas { get; set; }
        public string Alimento { get; set; } = null!;
        public string Medicamento { get; set; } = null!;
        public string Colmenar { get; set; } = null!;
        public int IdAlimento { get; set; }
        public int IdMedicamento { get; set; }
        public int IdColmenar { get; set; }
    }
}