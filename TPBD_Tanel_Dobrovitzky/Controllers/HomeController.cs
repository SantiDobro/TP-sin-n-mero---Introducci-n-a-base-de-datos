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
    public IActionResult Login(string usuario, string contraseña)
    {
       Integrante integranteEncontrado = Integrante.VerificarInicioSesion(usuario,contraseña);
       
       if (integranteEncontrado != null)
       {
         return RedirectToAction("Perfil");
       }
       else 
       {
        return View("ErrorInicioSesión");
       }
        return View("ErrorInicioSesión");
    }
    public IActionResult Perfil(Integrante integranteEncontrado)
    {
        ViewBag.integranteEncontrado = integranteEncontrado;
        return View();
    }
}
