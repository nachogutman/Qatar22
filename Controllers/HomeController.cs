using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Qatar22.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Qatar22.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment _environment)
    {        
        Environment = _environment;
    }

    public IActionResult Index()
    {
        ViewBag.Lista = BD.ListarEquipos();
        return View();
    }

    public IActionResult Continentes()
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

    [HttpPost] public IActionResult GuardarJugador(int IdEquipo,string Nombre,DateTime FechaNacimiento, IFormFile Foto,string EquipoActual, int NumCamiseta){
        
        if(Foto.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\jugadores\" + Foto.FileName;
            using(var stream = System.IO.File.Create(wwwRootLocal)){
                Foto.CopyToAsync(stream);
            }
        }

        Jugador newJug = new Jugador(IdEquipo, Nombre, FechaNacimiento, ("/" + Foto.FileName), EquipoActual, NumCamiseta);
        BD.AgregarJugador(newJug);
        return RedirectToAction("VerDetalleEquipo","Home", new {IdEquipo=IdEquipo});
    }

    [HttpPost] public IActionResult GuardarEquipo(string Nombre, IFormFile Escudo, IFormFile Camiseta, string Continente, int CopasGanadas){
        
        if(Escudo.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + Escudo.FileName;
            using(var stream = System.IO.File.Create(wwwRootLocal)){
                Escudo.CopyToAsync(stream);
            }
        }

        if(Camiseta.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + Camiseta.FileName;
            using(var stream = System.IO.File.Create(wwwRootLocal)){
                Camiseta.CopyToAsync(stream);
            }
        }       
        
        Equipo newEquipo = new Equipo(Nombre, ("/" + Escudo.FileName), ("/" + Camiseta.FileName), Continente, CopasGanadas);
        BD.AgregarEquipo(newEquipo);                
        return RedirectToAction("Index","Home");
    }

    public IActionResult EliminarJugador(int IdJugador, int IdEquipo){
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
