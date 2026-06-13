using HotelApp.Data;
using HotelApp.Models;

ReservaDAO dao = new ReservaDAO();

int opcion;

do
{
    Console.WriteLine("\nHotel");
    Console.WriteLine("1. Registrar reserva");
    Console.WriteLine("2. Listar reservas");
    Console.WriteLine("3. Calcular ingreso total");
    Console.WriteLine("4. Mostrar reserva de mayor duración");
    Console.WriteLine("5. Salir");

    Console.Write("Opción: ");
    opcion = int.Parse(Console.ReadLine() ?? "0");

    switch (opcion)
    {
        case 1:

            Reserva reserva = new Reserva();

            Console.Write("Nombre del cliente: ");
            reserva.NombreCliente = Console.ReadLine() ?? "";

            Console.Write("Número de habitación: ");
            reserva.NumeroHabitacion = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Fecha de ingreso (YYYY-MM-DD): ");
            reserva.FechaIngreso = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Número de noches: ");
            reserva.NumeroNoches = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Precio por noche: ");
            reserva.PrecioPorNoche = decimal.Parse(Console.ReadLine() ?? "0");

            dao.Registrar(reserva);
            break;

        case 2:
            dao.Listar();
            break;

        case 3:
            dao.CalcularIngresoTotal();
            break;

        case 4:
            dao.MostrarMayorDuracion();
            break;

    }

} while (opcion != 5);