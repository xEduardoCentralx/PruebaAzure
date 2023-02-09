using Campañas.Models;
using System.Data;
using System.Data.SqlClient;

namespace Campañas.Datos
{
    public class DA_Logica
    {
        public List<Empleado> Listar()
        {
            var oLista = new List<Empleado>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Empleado()
                        {
                            IdEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            Nombre = dr["nombre"].ToString(),
                            ApPaterno = dr["apPaterno"].ToString(),
                            ApMaterno = dr["apMaterno"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Contra = dr["contra"].ToString(),
                            Rol = Convert.ToString(dr["rol"])
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }
    }
}
