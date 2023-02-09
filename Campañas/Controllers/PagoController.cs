using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Campañas.Controllers
{
    [Authorize(Roles = "Administrador, Super usuario, Empleado")]
    public class PagoController : Controller
    {
        PagoDatos _PagoDatos = new PagoDatos();
        public IActionResult Listar()
        {
            var oLista = _PagoDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PagoModel oPago)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _PagoDatos.Guardar(oPago);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Editar(int id)
        {
            var oPago = _PagoDatos.Obtener(id);
            return View(oPago);
        }

        [HttpPost]
        public IActionResult Editar(PagoModel oPago)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PagoDatos.Editar(oPago);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [Authorize(Roles = "Administrador, Super usuario")]
        public IActionResult Eliminar(int id)
        {
            var oPago = _PagoDatos.Obtener(id);
            return View(oPago);
        }

        [HttpPost]
        public IActionResult Eliminar(PagoModel oPago)
        {
            var respuesta = _PagoDatos.Eliminar(oPago.idPago);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
