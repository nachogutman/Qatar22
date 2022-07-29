using System.Linq.Expressions;
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

    public IActionResult VerDetalleEquipo(int IdEquipo, int IdJugador){
        ViewBag.DetalleEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag.ListarJugadores = BD.ListarJugadores(IdEquipo);
        if(IdJugador != 0){
            ViewBag.DetalleJugador = BD.VerInfoJugador(IdJugador);
        }
        return View("DetalleEquipo");
    }

    public IActionResult VerDetalleJugador(int IdJugador){              
        ViewBag.DetalleJugador = BD.VerInfoJugador(IdJugador);
        return View("DetalleJugador");
    }

    public IActionResult AgregarJugador(int IdEquipo){
        ViewBag.IdEquipo = IdEquipo;
        ViewBag.ListaJugadores = BD.ListarJugadores(IdEquipo);
        return View("AgregarJugador");
    }

    public IActionResult AgregarEquipo(){
        return View("AgregarEquipo");
    }

    [HttpPost] public IActionResult GuardarJugador(int IdEquipo,string Nombre,DateTime FechaNacimiento, IFormFile Foto,string EquipoActual, int NumCamiseta){
                
        List<Jugador> listaJugadores = new List<Jugador>();
        listaJugadores = BD.ListarJugadores(IdEquipo);
        bool numeroRepetido = false;
        foreach(Jugador jug in listaJugadores){
            if(jug.NumCamiseta == NumCamiseta){
                numeroRepetido = true;
                ViewBag.numeroRepetido = numeroRepetido;
                return RedirectToAction("AgregarJugador","Home", new {IdEquipo=IdEquipo});
            }
        }

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

    [HttpPost] public IActionResult GuardarEquipo(string Nombre, IFormFile Escudo, IFormFile Camiseta, string Continente, int CopasGanadas, string Video){
        
        if(Escudo.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\equipos\" + Escudo.FileName;
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
        
        Equipo newEquipo = new Equipo(Nombre, ("/" + Escudo.FileName), ("/" + Camiseta.FileName), Continente, CopasGanadas, Video);
        BD.AgregarEquipo(newEquipo);                
        return RedirectToAction("Index","Home");
    }

    public IActionResult EliminarJugador(int IdJugador, int IdEquipo){
        BD.EliminarJugador(IdJugador);
        ViewBag.DetalleEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag.ListarJugadores = BD.ListarJugadores(IdEquipo);        
        return RedirectToAction("VerDetalleEquipo","Home", new {IdEquipo=IdEquipo});
    }

    public IActionResult EditarJugador(int IdJugador, int IdEquipo){
        ViewBag.IdEquipo = IdEquipo;
        ViewBag.IdEdit = IdJugador;
        return View("EditarJugador");
    }

    public IActionResult GuardarEdit(int IdJugador, int IdEquipo, string Nombre, DateTime FechaNacimiento, IFormFile Foto, string EquipoActual, int NumCamiseta){

        if(Foto.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\jugadores\" + Foto.FileName;
            using(var stream = System.IO.File.Create(wwwRootLocal)){
                Foto.CopyToAsync(stream);
            }
        }

        Jugador newJug = new Jugador(IdEquipo, Nombre, FechaNacimiento,  ("/" + Foto.FileName), EquipoActual,  NumCamiseta);
        BD.EditarJugador(newJug, IdJugador);
        return RedirectToAction("VerDetalleJugador","Home", new {IdJugador=IdJugador});

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
