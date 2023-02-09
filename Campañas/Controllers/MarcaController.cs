using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Campañas.Controllers
{
    [Authorize(Roles = "Administrador, Super usuario, Empleado")]
    public class MarcaController : Controller
    {
        MarcaDatos _MarcaDatos = new MarcaDatos();
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Listar(){
            var oLista = _MarcaDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Guardar(MarcaModel oMarca){
            if (!ModelState.IsValid)
            {return View();
            }
            var respuesta = _MarcaDatos.Guardar(oMarca);
            if (respuesta){
                return RedirectToAction("Listar");
            }else
            {return View();}
        }
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Editar(int id)
        {
            var oMarca = _MarcaDatos.Obtener(id);
            return View(oMarca);
        }

        [HttpPost]
        public IActionResult Editar(MarcaModel oMarca)
        {

            if (!ModelState.IsValid)
            { return View(); }
            var respuesta = _MarcaDatos.Editar(oMarca);
            if (respuesta) { 
                return RedirectToAction("Listar");
            }else 
            { return View(); }
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Eliminar(int id)
        {
            var oMarca = _MarcaDatos.Obtener(id);
            return View(oMarca);
        }

        [HttpPost]
        public IActionResult Eliminar(MarcaModel oMarca)
        {
            var respuesta = _MarcaDatos.Eliminar(oMarca.idMarca);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }else
            { return View(); }
        }
    }
}
