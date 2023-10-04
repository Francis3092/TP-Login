public class Usuario
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Contraseña { get; set; }
    public string Mail { get; set; }
    public string Telefono { get; set; }

    public Usuario()
    {

    }

    public Usuario(int id, string username, string contraseña, string mail, string telefono)
    {
        Id = id;
        UserName = username;
        Contraseña = contraseña;
        Mail = mail;
        Telefono = telefono;
    }
} 