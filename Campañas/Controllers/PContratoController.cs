using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Campañas.Controllers
{
    [Authorize (Roles = "Administrador, Super usuario, Empleado")]
    public class PContratoController : Controller
    {
        ContratoDatos _ContratoDatos = new ContratoDatos();
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Listar()
        {
            var oLista = _ContratoDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PContratoModel oContrato)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContratoDatos.Guardar(oContrato);
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
            var oContrato = _ContratoDatos.Obtener(id);
            return View(oContrato);
        }

        [HttpPost]
        public IActionResult Editar(PContratoModel oContrato)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContratoDatos.Editar(oContrato);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        [Authorize(Roles = "Administrador, Super usuario")]
        public IActionResult Eliminar(int id)
        {
            var oContrato = _ContratoDatos.Obtener(id);
            return View(oContrato);
        }

        [HttpPost]
        public IActionResult Eliminar(PContratoModel oContrato)
        {
            var respuesta = _ContratoDatos.Eliminar(oContrato.idHerramienta);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
    }
}
