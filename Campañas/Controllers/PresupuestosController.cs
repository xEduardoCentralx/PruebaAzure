using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Campañas.Controllers
{
    [Authorize(Roles = "Administrador, Super usuario, Empleado")]
    public class PresupuestosController : Controller
    {
        ContratoDatos _ContratoDatos = new ContratoDatos();
        private readonly CampañasContext _db;
        public PresupuestosController(CampañasContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Listado()
        {
            ViewBag.Derogado = _db.PDerogado.ToList();
            ViewBag.Ajustado = _db.PAjustado.ToList();
            ViewBag.Contrato = _db.PContrato.ToList();
            return View();
        }
    }
}
