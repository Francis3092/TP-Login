using Microsoft.AspNetCore.Mvc;

namespace TP_Login.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(string username, string contraseña)
    {
        if (BD.VerificarDatosLogin(username, contraseña) == null)
        {
            ViewBag.MensajeError = "Nombre de usuario o contraseña incorrectos";
            return View("Index");
        }
        else
        {
            ViewBag.MostrarDatos = BD.VerificarDatosLogin(username, contraseña);
            return View("PaginaInicio");
        }
    }

    public IActionResult Registro()
    {
        return View();
    }

    public IActionResult Registrarse(string username, string contraseña)
    {
        Usuario usuarioExistente = BD.ObtenerUsuario(username);

        if (usuarioExistente != null)
        {
            return RedirectToAction("Index");
        }
        else
        {
            BD.GuardarUsuario(username, contraseña);
            return RedirectToAction("PaginaInicio");
        }
    }

    public IActionResult OlvideMiContraseña()
    {
        return View();
    }

    public IActionResult CambiarContraseña(string username, string contraseña)
    {
        BD.ActualizarUsuario(username, contraseña);
        return View("Index");
    }
    
    public IActionResult PaginaInicio()
    {
        return View();
    }
}