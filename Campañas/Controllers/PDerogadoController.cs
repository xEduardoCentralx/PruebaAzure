using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Campañas.Controllers
{
    [Authorize(Roles ="Administrador, Super usuario, Empleado")]
    public class PDerogadoController : Controller
    {
        DerogadoDatos _DerogadoDatos = new DerogadoDatos();
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Listar()
        {
            var oLista = _DerogadoDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PDerogadoModel oDerogado)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _DerogadoDatos.Guardar(oDerogado);
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
            var oDerogado = _DerogadoDatos.Obtener(id);
            return View(oDerogado);
        }

        [HttpPost]
        public IActionResult Editar(PDerogadoModel oDerogado)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _DerogadoDatos.Editar(oDerogado);
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
            var oDerogado = _DerogadoDatos.Obtener(id);
            return View(oDerogado);
        }

        [HttpPost]
        public IActionResult Eliminar(PDerogadoModel oDerogado)
        {
            var respuesta = _DerogadoDatos.Eliminar(oDerogado.idHerramienta);
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
