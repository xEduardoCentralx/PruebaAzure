using Campañas.Models;
using Campañas.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Campañas.Servicios.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly CampañasContext _context;
        public EmpleadoService(CampañasContext context)
        {
            _context = context;
        }
        public async Task<Empleado>GetEmpleado(string correo, string contra)
        {
            Empleado empleadoEncontrado = await _context.Empleados.Where(u => u.Correo == correo && u.Contra == contra).FirstOrDefaultAsync();

            return empleadoEncontrado;
        }

        public async Task<Empleado>SaveEmpleado(Empleado modelo)
        {
            _context.Empleados.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}
