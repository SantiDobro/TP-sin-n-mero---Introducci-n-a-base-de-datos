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
        }
        else
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View("Index");
        }
    }
    public IActionResult Perfil(Integrante integranteEncontrado)
    {
        ViewBag.integranteEncontrado = integranteEncontrado;
        return View();
    }
}
