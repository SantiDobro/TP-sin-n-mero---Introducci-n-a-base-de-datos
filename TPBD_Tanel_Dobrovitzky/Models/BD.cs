using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=NombreBase; Integrated Security=True; TrustServerCertificate=True;";
    
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
}

