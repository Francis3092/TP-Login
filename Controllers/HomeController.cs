using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_Login.Models;

namespace TP_Login.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] 
    public IActionResult Index(string username, string contraseña)
    {
        List<Usuario> usuarios = BD.ObtenerUsuario(username);

        if (usuarios.Count > 0 && usuarios[0].Contraseña == contraseña)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.MensajeError = "Nombre de usuario o contraseña incorrectos";
        return View();
    }

    public IActionResult Registro()
    {
        return View("Index");
    }

    [HttpPost]
    public IActionResult Registro(string username, string contraseña)
    {
        List<Usuario> usuariosExistentes = BD.ObtenerUsuario(username);

        if (usuariosExistentes.Count > 0)
        {
            ViewBag.MensajeError = "Este nombre de usuario ya está en uso";
            return View();
        }

        Usuario nuevoUsuario = new Usuario{ UserName = username, Contraseña = contraseña};

        BD.GuardarUsuario(nuevoUsuario);

        return RedirectToAction("Index");
    }

    public IActionResult OlvideMiContraseña()
    {
        return View();
    }

    [HttpPost]
    public IActionResult OlvideMiContraseña(string username, string nuevaContraseña)
    {
        List<Usuario> usuarios = BD.ObtenerUsuario(username);

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}