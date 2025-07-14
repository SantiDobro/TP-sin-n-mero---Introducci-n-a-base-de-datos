using Microsoft.AspNetCore.Mvc;
using TP_sin_número___Introducción_a_base_de_datos.Models;

namespace TP_sin_número___Introducción_a_base_de_datos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string usuario = HttpContext.Session.GetString("usuario");

        if (!string.IsNullOrEmpty(usuario))
        {
            var integrante = Integrante.BuscarPorUsuario(usuario);
            return View(integrante);
        }

        return View(null); // sin loguear
    }

    public IActionResult IniciarSesion()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usuario, string contraseña)
    {
        var integrante = Integrante.LevantarIntegrante(usuario, contraseña);

        if (integrante != null)
        {
            HttpContext.Session.SetString("usuario", integrante.Usuario);
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View("IniciarSesion");
        }
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
