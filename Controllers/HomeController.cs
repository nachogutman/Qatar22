using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Qatar22.Models;

namespace Qatar22.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Lista = BD.ListarEquipos();
        return View();
    }

    public IActionResult VerDetalleEquipo(int IdEquipo){
        ViewBag.DetalleEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag.ListarJugadores = BD.ListarJugadores(IdEquipo);
        return View("DetalleEquipo");
    }

    public IActionResult VerDetalleJugador(int IdJugador){
        ViewBag.DetalleJugador = BD.VerInfoJugador(IdJugador);
        return View("DetalleJugador");
    }

    public IActionResult AgregarJugador(int IdEquipo){
        ViewBag.IdEquipo = IdEquipo;
        return View("AgregarJugador");
    }

    [HttpPost] public IActionResult GuardarJugador(int IdEquipo,string Nombre,DateTime FechaNacimiento,string Foto,string EquipoActual){
        Jugador newJug = new Jugador(IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual);
        BD.AgregarJugador(newJug);
        ViewBag.DetalleEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag.ListarJugadores = BD.ListarJugadores(IdEquipo);
        return View("DetalleEquipo");

    }

    IActionResult EliminarJugador(int IdJugador, int IdEquipo){
        BD.EliminarJugador(IdJugador);
        ViewBag.DetalleEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag.ListarJugadores = BD.ListarJugadores(IdEquipo);
        return View("DetalleEquipo");
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
