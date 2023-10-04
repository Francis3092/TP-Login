using System.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _ConnectionString = @"Server=localhost; DataBase=loginDB; Trusted_Connection=True;";

    public static List<Usuario> ObtenerUsuario()
    {
        List<Usuario> _ListadoUsuarios;
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            string SQL = "SELECT * From Usuario";
            _ListadoUsuarios = db.Query<Usuario>(SQL).ToList();
        }
        return _ListadoUsuarios;
    }

    public static bool VerificarDatosLogin(string username, string contraseña)
    {
        string SQL = "SELECT * From Usuario WHERE UserName = @pUserName AND Contraseña = @pContraseña";
        Usuario datos = null;
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            datos = db.QueryFirstOrDefault<Usuario>(SQL, new {pContraseña = contraseña, pUserName = username});
        }

        if (datos == null)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }

    public static void GuardarUsuario(Usuario usuario)
    {
        string SQL = "INSERT INTO Usuario (UserName, Contraseña) VALUES (@pUserName, @pContraseña)";
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            db.Execute(SQL, new { pUserName = usuario.UserName, pContraseña = usuario.Contraseña });
        }
    }

    public static void ActualizarUsuario(Usuario usuario)
    {
        string SQL = "UPDATE Usuario SET Contraseña = @Contraseña WHERE UserName = @UserName";
        using (SqlConnection db = new SqlConnection(_ConnectionString))
        {
            db.Execute(SQL);
        }
    }
}