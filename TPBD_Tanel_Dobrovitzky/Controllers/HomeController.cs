using System.Diagnostics;
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
        return View();
    }
    [HttpPost]
    public IActionResult Login(string usuario, string contraseña)
    {
        var integrante = Integrante.LevantarIntegrante(usuario, contraseña);

        if (integrante != null)
        {
            return View("Perfil", integrante);
            HttpContext.Session.SetString("usuario", integrante.Usuario);
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View("Index");
        }
    }
    public IActionResult Perfil(Integrante integranteEncontrado)
    {
        string usuario = HttpContext.Session.GetString("usuario");

        if (string.IsNullOrEmpty(usuario))
            return RedirectToAction("Index");

        var integrante = Integrante.BuscarPorUsuario(usuario);
        return View(integrante);
    }
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear(); // Borra todos los datos de sesión
        return RedirectToAction("Index");
    }
}
