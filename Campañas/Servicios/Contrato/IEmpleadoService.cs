using Microsoft.EntityFrameworkCore;
using Campañas.Models;

namespace Campañas.Servicios.Contrato
{
    public interface IEmpleadoService
    {
        Task<Empleado> GetEmpleado(string correo, string contra);
        Task<Empleado> SaveEmpleado(Empleado modelo);
    }
}
