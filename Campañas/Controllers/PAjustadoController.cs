using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Campañas.Controllers
{
    [Authorize (Roles = "Administrador, Super usuario, Empleado")]
    public class PAjustadoController : Controller
    {
        AjustadoDatos _AjustadoDatos = new AjustadoDatos();
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Listar()
        {
            var oLista = _AjustadoDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PAjustadoModel oAjustado)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _AjustadoDatos.Guardar(oAjustado);
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
            var oAjustado = _AjustadoDatos.Obtener(id);
            return View(oAjustado);
        }

        [HttpPost]
        public IActionResult Editar(PAjustadoModel oAjustado)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _AjustadoDatos.Editar(oAjustado);
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
            var oAjustado = _AjustadoDatos.Obtener(id);
            return View(oAjustado);
        }

        [HttpPost]
        public IActionResult Eliminar(PAjustadoModel oAjustado)
        {
            var respuesta = _AjustadoDatos.Eliminar(oAjustado.idHerramienta);
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
