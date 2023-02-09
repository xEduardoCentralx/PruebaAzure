using Microsoft.AspNetCore.Mvc;
using Campañas.Datos;
using Campañas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Campañas.Controllers
{
    [Authorize (Roles = "Administrador, Super usuario , Empleado")]
    public class ClienteController : Controller
    {
        ClienteDatos _ClienteDatos = new ClienteDatos();
        public IActionResult Listar()
        {
            /*Nos devuelve una vista con la lista de empleados que hay en la tabla
             La lista sera guardada en la varible llamada oLista
            Y como queremos que la lista se vea en nuestra Vista, le pasamos la variable al metodo view*/
            var oLista = _ClienteDatos.Listar();
            return View(oLista);
        }
        [Authorize(Roles = "Administrador, Super usuario , Empleado")]
        public IActionResult Guardar()
        {
            //Nos devuelve una vista para guardar los datos
            return View();
        }

        //Usamos el httpost para diferenciar del primero y segundo metodo
        [HttpPost]
        //Este metodo va a recibir los parametros del EmpleadoModel
        public IActionResult Guardar(ClienteModel oCliente)
        {
            //Validamos que los campos ingresados sean obligatorios y esten completos
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Recibe los datos para guardarlos en la BD usando el metodo Guardar  de la clase EmpleadoDatos
            var respuesta = _ClienteDatos.Guardar(oCliente);
            //Si la variable respuesta logra guardar los datos nos va a redirigir a la vista Listar
            if (respuesta)
            {
                return RedirectToAction("Listar");
                //Pero si no logra guardar los datos, nos regresa a la vista de guardar
            }
            else
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Super usuario")]
        public IActionResult Editar(int id)
        {
            //Nos devuelve una vista para guardar los datos
            var oCliente = _ClienteDatos.Obtener(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel oCliente)
        {

            if (!ModelState.IsValid)

                return View();

            //Recibe los datos para guardarlos en la BD usando el metodo Guardar  de la clase EmpleadoDatos
            var respuesta = _ClienteDatos.Editar(oCliente);
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
            var oCliente = _ClienteDatos.Obtener(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(ClienteModel oCliente)
        {
            //Recibe los datos para guardarlos en la BD usando el metodo Guardar  de la clase EmpleadoDatos
            var respuesta = _ClienteDatos.Eliminar(oCliente.idCliente);
            //Si la variable respuesta logra guardar los datos nos va a redirigir a la vista Listar
            if (respuesta)
                return RedirectToAction("Listar");

            //Pero si no logra guardar los datos, nos regresa a la vista de guardar
            else
                return View();
        }
    }
}
