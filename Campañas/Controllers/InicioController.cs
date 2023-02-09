using Microsoft.AspNetCore.Mvc;

using Campañas.Models;
using Campañas.Recursos;
using Campañas.Servicios.Contrato;
using Campañas.Datos;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Campañas.Controllers
{
    public class InicioController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        public InicioController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }
        public IActionResult InicioSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InicioSesion(string correo, string contra)
        {
            DA_Logica da_empleado = new DA_Logica();


            Empleado empleado_encontrado = await _empleadoService.GetEmpleado(correo, Utilidades.EncriptarContra(contra));

            if (empleado_encontrado == null)
            {
                ViewData["Mensaje"] = "Empleado no encontrado";
                return View();
            }
            else
            {
                List<Claim> claims = new List<Claim>(){
                new Claim(ClaimTypes.Name, empleado_encontrado.Nombre)
                };
                claims.Add(new Claim(ClaimTypes.Role, empleado_encontrado.Rol));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                properties);
                return RedirectToAction("Listado", "Presupuestos");
            }
        }
    }
}
