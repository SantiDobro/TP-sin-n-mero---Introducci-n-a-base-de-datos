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
        if(Integrante.VerificarInicioSesion(usuario,contraseña))
        {
            Integrante integranteEncontrado = Integrante.VerificarInicioSesion(usuario,contraseña).integranteEncontrado;
        }
        return View("Index");
    }
    public IActionResult Perfil()
    {
        return View();
    }
}
