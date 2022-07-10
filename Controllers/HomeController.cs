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

    public IActionResult AgregarEquipo(){
        return View("AgregarEquipo");
    }

    [HttpPost] public IActionResult GuardarJugador(int IdEquipo,string Nombre,DateTime FechaNacimiento,string Foto,string EquipoActual){
        Jugador newJug = new Jugador(IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual);
        BD.AgregarJugador(newJug);
        ViewBag.DetalleEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag.ListarJugadores = BD.ListarJugadores(IdEquipo);
        return View("DetalleEquipo");
    }

    [HttpPost] public IActionResult GuardarEquipo(string Nombre,string Escudo,string Camiseta,string Continente, int CopasGanadas){
        Equipo newEquipo = new Equipo(Nombre, Escudo, Camiseta, Continente, CopasGanadas);
        BD.AgregarEquipo(newEquipo);
        ViewBag.ListaEquipos = BD.ListarEquipos();
        int IdEquipo = ViewBag.ListaEquipos.Count() - 1;
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
