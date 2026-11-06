namespace Apicola.Application.DTOs.CuradoAlimentado
{
    public class HistorialColmenarRequestDto
    {
        public int Id { get; set; }
        public bool? Curado { get; set; }
        public bool? Alimentado { get; set; }
        public int CantidadMuertas { get; set; }
        public DateTime FechaVisita { get; set; }
        public int? IdColmenar { get; set; }
        public int? IdAlimento { get; set; }
        public int? IdMedicamento { get; set; }
    }
}