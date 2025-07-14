using Microsoft.Data.SqlClient;
using Dapper;

public class Integrante
{
    public string Usuario { get; set; }
    public string Contraseña { get; set; }
    public string Genero { get; set; }
    public string Color { get; set; }
    public string Equipo { get; set; }
    public string Pais { get; set; }
    public string Telefono { get; set; }

    public Integrante() { }
    
    public static Integrante LevantarIntegrante(string usuario, string contraseña)
    {
    using (SqlConnection connection = BD.ObtenerConexion())
    {
        string query = "SELECT * FROM Integrante WHERE Usuario = @usuario AND Contraseña = @contraseña";
        return connection.QueryFirstOrDefault<Integrante>(query, new { usuario, contraseña });
    }
    }
    public static Integrante BuscarPorUsuario(string usuario)
{
    using (SqlConnection connection = BD.ObtenerConexion())
    {
        string query = "SELECT * FROM Integrante WHERE Usuario = @usuario";
        return connection.QueryFirstOrDefault<Integrante>(query, new { usuario });
    }
}
}

