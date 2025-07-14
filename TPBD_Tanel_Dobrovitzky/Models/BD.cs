using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=DESKTOP-D0RO1QD\SQLEXPRESS; DataBase=BD_Integrantes; Integrated Security=True; TrustServerCertificate=True;";
    
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_connectionString);
    }
}

