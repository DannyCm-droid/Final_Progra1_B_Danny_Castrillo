using MySql.Data.MySqlClient;
using HotelApp.Models;

namespace HotelApp.Data;

public class ReservaDAO
{
    private ConexionDB conexionDB = new ConexionDB();

    public void Registrar(Reserva reserva)
    {
        using var conexion = conexionDB.ObtenerConexion();
        conexion.Open();

        string sql =
            @"INSERT INTO reservas
            (nombre_cliente, numero_habitacion, fecha_ingreso, numero_noches, precio_por_noche)
            VALUES
            (@nombre, @habitacion, @fecha, @noches, @precio)";

        using var cmd = new MySqlCommand(sql, conexion);

        cmd.Parameters.AddWithValue("@nombre", reserva.NombreCliente);
        cmd.Parameters.AddWithValue("@habitacion", reserva.NumeroHabitacion);
        cmd.Parameters.AddWithValue("@fecha", reserva.FechaIngreso);
        cmd.Parameters.AddWithValue("@noches", reserva.NumeroNoches);
        cmd.Parameters.AddWithValue("@precio", reserva.PrecioPorNoche);

        cmd.ExecuteNonQuery();

        Console.WriteLine("Reserva registrada.");
    }

    public void Listar()
    {
        using var conexion = conexionDB.ObtenerConexion();
        conexion.Open();

        string sql = "SELECT * FROM reservas";

        using var cmd = new MySqlCommand(sql, conexion);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("\nLISTA DE RESERVAS");

        while (reader.Read())
        {
            Console.WriteLine(
                $"ID: {reader["id"]} | " +
                $"Cliente: {reader["nombre_cliente"]} | " +
                $"Habitación: {reader["numero_habitacion"]} | " +
                $"Fecha: {reader["fecha_ingreso"]} | " +
                $"Noches: {reader["numero_noches"]} | " +
                $"Precio: {reader["precio_por_noche"]}");
        }
    }

    public void CalcularIngresoTotal()
    {
        using var conexion = conexionDB.ObtenerConexion();
        conexion.Open();

        string sql =
            "SELECT SUM(numero_noches * precio_por_noche) AS total FROM reservas";

        using var cmd = new MySqlCommand(sql, conexion);

        var resultado = cmd.ExecuteScalar();

        Console.WriteLine($"Ingreso total esperado: Q{resultado}");
    }

    public void MostrarMayorDuracion()
    {
        using var conexion = conexionDB.ObtenerConexion();
        conexion.Open();

        string sql =
            @"SELECT * FROM reservas
              ORDER BY numero_noches DESC
              LIMIT 1";

        using var cmd = new MySqlCommand(sql, conexion);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine("\nRESERVA DE MAYOR DURACIÓN");

            Console.WriteLine(
                $"Cliente: {reader["nombre_cliente"]} | " +
                $"Habitación: {reader["numero_habitacion"]} | " +
                $"Noches: {reader["numero_noches"]}");
        }
    }
}