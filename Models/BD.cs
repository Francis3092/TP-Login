using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _ConnectionString = @"Server=localhost; DataBase=BDLogin; Trusted_Connection=True;";

    public static Usuario ObtenerUsuario(string username)
    {
        Usuario usuario = null;
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "SELECT * From Usuario WHERE UserName = @username";
            usuario = db.QueryFirstOrDefault<Usuario>(SQL, new { UserName = username });
        }
        return usuario;
    }

    public static Usuario VerificarDatosLogin(string username, string contraseña)
    {
        Usuario validacionUsuario = null;
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "SELECT * FROM Usuario WHERE UserName = @pUserName AND Contraseña = @pContraseña";
            validacionUsuario = db.QueryFirstOrDefault<Usuario>(SQL, new { pUserName = username, pContraseña = contraseña });
        }

        return validacionUsuario;
    }

    public static void GuardarUsuario(Usuario usuario)
    {
        string SQL = "INSERT INTO Usuario (UserName, Contraseña, Mail, Telefono) VALUES (@pUserName, @pContraseña, @pMail, @pTelefono)";
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            db.Execute(SQL, new { pUserName = usuario.UserName, pContraseña = usuario.Contraseña, pMail = usuario.Mail, pTelefono = usuario.Telefono });
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