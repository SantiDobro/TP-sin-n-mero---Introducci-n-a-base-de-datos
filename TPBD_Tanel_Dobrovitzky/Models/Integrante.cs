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

    public Integrante(string usuario, string contraseña, string genero, string color, string equipo, string pais, string telefono)
    {
        Usuario = usuario;
        Contraseña = contraseña;
        Genero = genero;
        Color = color;
        Equipo = equipo;
        Pais = pais;
        Telefono = telefono;
    }
    public Integrante() { }
    public static List<Integrante> LevantarIntegrante(string usuario, string contraseña)
    {
        Integrante integranteEncontrado = new Integrante();
        using (SqlConnection connection = BD.ObtenerConexion())
        {
            string query = "SELECT * FROM Integrantes WHERE Usuario = @usuario AND Contraseña = @contraseña";
            integranteEncontrado = connection.QueryFirstOrDefault<Integrante>(query)();
        }
        return integranteEncontrado;
    }
}

