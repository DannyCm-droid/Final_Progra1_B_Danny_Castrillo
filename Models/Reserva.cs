namespace HotelApp.Models;

public class Reserva
{
    public int Id { get; set; }
    public string NombreCliente { get; set; } = "";
    public int NumeroHabitacion { get; set; }
    public DateTime FechaIngreso { get; set; }
    public int NumeroNoches { get; set; }
    public decimal PrecioPorNoche { get; set; }
}