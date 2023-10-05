using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _ConnectionString = @"Server=localhost; DataBase=loginDB; Trusted_Connection=True;";

    public static Usuario ObtenerUsuario(string username)
    {
        string SQL = "SELECT * From Usuario WHERE UserName = @username";
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            return db.QueryFirstOrDefault<Usuario>(SQL, new {username});
        }
    }

    public static Usuario VerificarDatosLogin(string username, string contraseña)
    {
        Usuario usuario = null;
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "SELECT * FROM Usuario WHERE UserName = @pUserName AND Contraseña = @pContraseña";
            usuario = db.QueryFirstOrDefault<Usuario>(SQL, new { pUserName = username, pContraseña = contraseña });
        }
        return usuario;
    }

    public static void GuardarUsuario(string username, string contraseña)
    {
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "INSERT INTO Usuario (UserName, Contraseña) VALUES (@pUserName, @pContraseña)";
            db.Execute(SQL, new { pUserName = username, pContraseña = contraseña });
        }
    }

    public static void ActualizarUsuario(string username, string contraseña)
    {
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "UPDATE Usuario SET Contraseña = @pContraseña WHERE UserName = @pUserName";
            db.Execute(SQL, new { pUserName = username, pContraseña = contraseña });
        }
    }
}