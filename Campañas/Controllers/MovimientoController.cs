using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Campañas.Controllers
{
    [Authorize(Roles = "Administrador, Super usuario, Empleado")]

    public class MovimientoController : Controller
    {
        private readonly CampañasContext _db;

        public MovimientoController( CampañasContext db)
        {
            _db = db;
        }

        MovimientoDatos _MovimientoDatos = new MovimientoDatos();
        public IActionResult Listar()
        {
            ViewBag.Movimiento = _db.Movimientos.ToList();
            var oLista = _MovimientoDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(MovimientoModel oMovimiento)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _MovimientoDatos.Guardar(oMovimiento);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {return View();}
        }
        [Authorize(Roles = "Administrador, Super usuario")]
        public IActionResult Editar(int id)
        {
            var oMovimiento = _MovimientoDatos.Obtener(id);
            return View(oMovimiento);
        }

        [HttpPost]
        public IActionResult Editar(MovimientoModel oMovimiento)
        {

            if (!ModelState.IsValid) { 
                return View(); }
            var respuesta = _MovimientoDatos.Editar(oMovimiento);
            if (respuesta) { 
                return RedirectToAction("Listar"); 
            }else { return View(); }
                
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Eliminar(int id)
        {
            var oMovimiento = _MovimientoDatos.Obtener(id);
            return View(oMovimiento);
        }

        [HttpPost]
        public IActionResult Eliminar(MovimientoModel oMovimiento)
        {
            var respuesta = _MovimientoDatos.Eliminar(oMovimiento.idMovimiento);
            if (respuesta) { 
                return RedirectToAction("Listar");
            }
            else { return View(); }
                
        }
    }
}
