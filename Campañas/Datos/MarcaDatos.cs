using Campañas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
namespace Campañas.Datos
{
    public class MarcaDatos{
        public List<MarcaModel> Listar()
        {
            var oLista = new List<MarcaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaMarca", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new MarcaModel()
                        {
                            idMarca = Convert.ToInt32(dr["idMarca"]),
                            nombre = dr["nombre"].ToString(),
                            tipo = dr["tipo"].ToString(),
                            fecha = dr["fecha"].ToString(),
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            idEmpleado = Convert.ToInt32(dr["idEmpleado"])
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }
        public MarcaModel Obtener(int id)
        {
            var oModelo = new MarcaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaMarca", conexion);
                cmd.Parameters.AddWithValue("idMarca", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oModelo.idMarca = Convert.ToInt32(dr["idMarca"]);
                        oModelo.nombre = dr["nombre"].ToString();
                        oModelo.tipo = dr["tipo"].ToString();
                        oModelo.fecha = dr["fecha"].ToString();
                        oModelo.idCliente = Convert.ToInt32(dr["idCliente"]);
                        oModelo.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                    }
                }
                conexion.Close();
            }
            return oModelo;
        }

        public bool Guardar(MarcaModel oMarca)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaMarca", conexion);
                    cmd.Parameters.AddWithValue("nombre", oMarca.nombre);
                    cmd.Parameters.AddWithValue("tipo", oMarca.tipo);
                    cmd.Parameters.AddWithValue("fecha", oMarca.fecha);
                    cmd.Parameters.AddWithValue("idCliente", oMarca.idCliente);
                    cmd.Parameters.AddWithValue("idEmpleado", oMarca.idEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Editar(MarcaModel oMarca)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditaMarca", conexion);
                    cmd.Parameters.AddWithValue("idMarca", oMarca.idMarca);
                    cmd.Parameters.AddWithValue("nombre", oMarca.nombre);
                    cmd.Parameters.AddWithValue("tipo", oMarca.tipo);
                    cmd.Parameters.AddWithValue("fecha", oMarca.fecha);
                    cmd.Parameters.AddWithValue("idCliente", oMarca.idCliente);
                    cmd.Parameters.AddWithValue("idEmpleado", oMarca.idEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_BorraMarca", conexion);
                    cmd.Parameters.AddWithValue("idMarca", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
