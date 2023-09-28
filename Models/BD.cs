using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _ConnectionString = @"Server=localhost; DataBase=loginDB; Trusted_Connection=True;";

    public static List<Usuario> ObtenerUsuario(string userName)
    {
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "SELECT * From Usuario WHERE UserName = @UserName";
            return db.Query<Usuario>(SQL, new { UserName = userName }).ToList();
        }
    }

    public static void GuardarUsuario(Usuario usuario)
    {
        string SQL = "INSERT INTO Usuario (UserName, Contraseña) VALUES (@UserName, @Contraseña)";
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            db.Execute(SQL, usuario);
        }
    }

    public static void ActualizarUsuario(Usuario usuario)
    {
        string SQL = "UPDATE Usuario SET Contraseña = @Contraseña WHERE UserName = @UserName";
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            db.Execute(SQL, usuario);
        }
    }
}