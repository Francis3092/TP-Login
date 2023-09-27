using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TP_Login.Models;

namespace TP_Login.Controllers;

public class AccountController : Controller
{
    private readonly UsuarioDBContext _context;

    public AccountController(UsuarioDBContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.UserName == model.UserName && u.Contraseña == model.Contraseña);

            if (user != null)
            {
                // Autenticación exitosa
                // Aquí puedes implementar la lógica para iniciar sesión y redirigir al usuario a la página de bienvenida
                return RedirectToAction("Bienvenida");
            }
            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            }
        }
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    // Acción para procesar el registro de usuario
    [HttpPost]
    public IActionResult Registro(UsuarioModel model)
    {
        if (ModelState.IsValid)
        {
            // Validar la contraseña nuevamente en el servidor
            if (!EsContraseñaValida(model.Contraseña))
            {
                ModelState.AddModelError("", "La contraseña no cumple con los requisitos.");
                return View(model);
            }

            // Aquí debes implementar la lógica para agregar el usuario a la base de datos
            // Asegúrate de almacenar la contraseña de forma segura (hashing y salting)

            // Después de registrar al usuario, puedes redirigirlo al inicio de sesión
            return RedirectToAction("Login");
        }
        return View(model);
    }

    public IActionResult OlvideContraseña()
    {
        return View();
    }

    // Acción para procesar la recuperación de contraseña
    [HttpPost]
    public IActionResult OlvideContraseña(RecuperarContraseñaViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Aquí debes implementar la lógica para enviar un correo con instrucciones para restablecer la contraseña
            // Puedes generar un token temporal y enviarlo por correo

            // Después de enviar el correo, puedes redirigir al usuario a una página de confirmación
            return RedirectToAction("ConfirmacionRecuperacion");
        }
        return View(model);
    }

    // Acción para la página de bienvenida
    public IActionResult Bienvenida()
    {
        // Aquí puedes mostrar los datos del usuario logueado
        return View();
    }

    // Función para validar la contraseña en el servidor
    private bool EsContraseñaValida(string contraseña)
    {
        // Implementa aquí la lógica para verificar la contraseña (mayúscula, carácter especial y longitud)
        // Devuelve true si la contraseña es válida, de lo contrario, devuelve false
        return true;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
