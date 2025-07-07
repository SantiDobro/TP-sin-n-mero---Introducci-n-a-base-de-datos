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
  public Integrante() { } // Necesario para que Dapper funcione bien
    public static List<Integrante> LevantarIntegrantes()
    {
        List<Integrante> integrantes = new List<Integrante>();
        using (SqlConnection connection = BD.ObtenerConexion())
        {
            string query = "SELECT * FROM Integrantes";
            integrantes = connection.Query<Integrante>(query).ToList();
        }
        return integrantes;
    }
    public static bool VerificarInicioSesion(string usuario, string contraseña)
    {
        Integrante integranteEncontrado = null;
        bool inicioSesion = false;
       List<Integrante> integrantes = LevantarIntegrantes();
        
      for (int i = 0; i < integrantes.Count; i++)
        {
        if(integrantes[i].usuario == usuario && integrantes[i].contraseña == contraseña) 
     {
     inicioSesion = true;
     integrantes[i] = integranteEncontrado;
    }
       }
    }
}

