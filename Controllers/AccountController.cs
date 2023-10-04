using Microsoft.AspNetCore.Mvc;

namespace TP_Login.Controllers;

public class AccountController : Controller
{

    public IActionResult Index(string username, string contraseña)
    {
        List<Usuario> usuarios = BD.ObtenerUsuario();
        ViewBag.ListaUsuarios = BD.ObtenerUsuario();

        if (usuarios.Count < 0 && usuarios[0].Contraseña != contraseña)
        {
            ViewBag.MensajeError = "Nombre de usuario o contraseña incorrectos";
        }
        return View();
    }

    public IActionResult Registro(string username, string contraseña)
    {
        List<Usuario> usuariosExistentes = BD.ObtenerUsuario();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(contraseña))
        {
            ViewBag.MensajeError = "El nombre de usuario y la contraseña son obligatorios";
            return View();
        }

        if (usuariosExistentes.Count > 0)
        {
            ViewBag.MensajeError = "Este nombre de usuario ya está en uso";
            return View();
        }
        else 
        {
            Usuario nuevoUsuario = new Usuario{ UserName = username, Contraseña = contraseña};
            BD.GuardarUsuario(nuevoUsuario);
            ViewBag.UserName = username;
            return RedirectToAction("PaginaInicio");
        }
    }

    public IActionResult Login(string username, string contraseña)
    {
        if (BD.VerificarDatosLogin(username, contraseña))
        {
            return RedirectToAction("PaginaInicio");
        }
        else 
        {
            ViewBag.MensajeError = "Nombre de usuario o contraseña incorrectos";
            return View("Index");
        }
    }

    public IActionResult OlvideMiContraseña(string username, string nuevaContraseña)
    {
        List<Usuario> usuarios = BD.ObtenerUsuario();

        if (usuarios.Count > 0)
        {
            usuarios[0].Contraseña = nuevaContraseña;
            BD.ActualizarUsuario(usuarios[0]);

            ViewBag.MensajeExito = "La contraseña se ha restablecido exitosamente";
        }
        else
        {
            ViewBag.MensajeError = "No se encontró ningún usuario con ese nombre de usuario";
        }

        return View();
    }

    public string GetPaginaInicioUrl()
    {
        return Url.Action("PaginaInicio", "Home");
    }

    public IActionResult PaginaInicio()
    {
        // Verifica si ViewBag.UserName está configurado y si no, redirige a la acción Index
        if (ViewBag.UserName == null)
        {
            return RedirectToAction("Index");
        }
    
        return View();
    }
}