public class Usuario
{
    public string UserName { get; set; }
    public string Contraseña { get; set; }
    public string Mail { get; set; }
    public string Telefono { get; set; }

    public Usuario()
    {

    }

    public Usuario(string username, string contraseña, string mail, string telefono)
    {
        UserName = username;
        Contraseña = contraseña;
        Mail = mail;
        Telefono = telefono;
    }
} 