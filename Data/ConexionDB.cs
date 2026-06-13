using MySql.Data.MySqlClient;

namespace HotelApp.Data;

public class ConexionDB
{
    private string cadena =
        "server=localhost;database=hotel_db;user=root;password=;";

    public MySqlConnection ObtenerConexion()
    {
        return new MySqlConnection(cadena);
    }
}