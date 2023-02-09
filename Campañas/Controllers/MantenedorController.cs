using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;
using Campañas.Recursos;

namespace Campañas.Controllers
{
    [Authorize(Roles = "Administrador, Super usuario, Empleado")]
    //Es muy importante dejar la palabra Controller para que el sistema sepa que es un controlador
    public class MantenedorController : Controller
    {
        //Creamos esta nueva referencia a nuestra clase de EmpleadoDatos
        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();
        [Authorize(Roles = "Administrador, Super usuario, Empleado")]
        public IActionResult Listar()
        {
            /*Nos devuelve una vista con la lista de empleados que hay en la tabla
             La lista sera guardada en la varible llamada oLista
            Y como queremos que la lista se vea en nuestra Vista, le pasamos la variable al metodo view*/
            var oLista = _EmpleadoDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario")]
        public IActionResult Guardar(){
            //Nos devuelve una vista para guardar los datos
            return View();
        }
        //Usamos el httpost para diferenciar del primero y segundo metodo
        [HttpPost]
        //Este metodo va a recibir los parametros del EmpleadoModel
        public IActionResult Guardar(Empleado oEmpleado){
            //Validamos que los campos ingresados sean obligatorios y esten completos
            oEmpleado.Contra = Utilidades.EncriptarContra(oEmpleado.Contra);
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Recibe los datos para guardarlos en la BD usando el metodo Guardar  de la clase EmpleadoDatos
            var respuesta = _EmpleadoDatos.Guardar(oEmpleado);
            //Si la variable respuesta logra guardar los datos nos va a redirigir a la vista Listar
            if (respuesta){
                return RedirectToAction("Listar");
                //Pero si no logra guardar los datos, nos regresa a la vista de guardar
            }else { 
            return View();
            }
        }
        [Authorize(Roles = "Administrador,  Super usuario")]
        public IActionResult Editar(int id)
        {
            //Nos devuelve una vista para guardar los datos
            var oEmpleado = _EmpleadoDatos.Obtener(id);
            return View(oEmpleado);
        }
        [HttpPost]
        public IActionResult Editar(Empleado oEmpleado)
        {
            if (!ModelState.IsValid)
                return View();
            //Recibe los datos para guardarlos en la BD usando el metodo Guardar  de la clase EmpleadoDatos
            oEmpleado.Contra = Utilidades.EncriptarContra(oEmpleado.Contra);
            var respuesta = _EmpleadoDatos.Editar(oEmpleado);
            //Si la variable respuesta logra guardar los datos nos va a redirigir a la vista Listar
            if (respuesta)
                return RedirectToAction("Listar");

            //Pero si no logra guardar los datos, nos regresa a la vista de guardar
            else
                return View();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Eliminar(int id)
        {
            //Nos devuelve una vista para guardar los datos
            var oEmpleado = _EmpleadoDatos.Obtener(id);
            return View(oEmpleado);
        }
        [HttpPost]
        public IActionResult Eliminar(Empleado oEmpleado)
        {
            //Recibe los datos para guardarlos en la BD usando el metodo Guardar  de la clase EmpleadoDatos
            var respuesta = _EmpleadoDatos.Eliminar(oEmpleado.IdEmpleado);
            //Si la variable respuesta logra guardar los datos nos va a redirigir a la vista Listar
            if (respuesta)
                return RedirectToAction("Listar");

            //Pero si no logra guardar los datos, nos regresa a la vista de guardar
            else
                return View();
        }
    }
}
