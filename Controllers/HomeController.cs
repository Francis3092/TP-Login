using Microsoft.AspNetCore.Mvc;

namespace TP_Login.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerificarLogin(string username, string contraseña)
    {
        Usuario datos = BD.VerificarDatosLogin(username, contraseña);

        if (datos == null)
        {
            ViewBag.ErrorMessage = "Nombre de usuario o contrasena incorrectos";
            return View("Index");
        }
        else
        {
            ViewBag.MostrarDatos = datos;
            ViewBag.SuccessMessage = "Inicio de sesión exitoso. ¡Bienvenido!";
            return View("PaginaInicio");
        }
    }

    public IActionResult Registro()
    {
        return View();
    }

    public IActionResult Registrarse(string username, string contraseña, string mail, string telefono)
    {
        Usuario nuevoUsuario = new Usuario(username, contraseña, mail, telefono);
        BD.GuardarUsuario(nuevoUsuario);
        return View("Index");
    }

    public IActionResult OlvideMiContraseña()
    {
        return View();
    }

    public IActionResult CambiarContraseña(string username, string contraseña)
    {
        Usuario usuario = BD.ObtenerUsuario(username);

        if (usuario == null)
        {
            ViewBag.MensajeError = "Nombre de usuario o contraseña incorrectos";
            return View("OlvideMiContraseña");
        }
        else
        {
            BD.ActualizarUsuario(username, contraseña);
            return View("Index");
        }
    }
    
    public IActionResult PaginaInicio()
    {
        return View();
    }
}