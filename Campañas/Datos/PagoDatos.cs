using Campañas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Campañas.Datos
{
    public class PagoDatos{
        public List<PagoModel> Listar()
        {
            var oLista = new List<PagoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaPago", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PagoModel()
                        {
                            idPago = Convert.ToInt32(dr["idPago"]),
                            nombre = dr["nombre"].ToString()
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }

        public PagoModel Obtener(int id)
        {
            var oModelo = new PagoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaPago", conexion);
                cmd.Parameters.AddWithValue("idPago", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oModelo.idPago = Convert.ToInt32(dr["idPago"]);
                        oModelo.nombre = dr["nombre"].ToString();

                    }
                }
                conexion.Close();
            }
            return oModelo;
        }

        public bool Guardar(PagoModel oPago)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaPago", conexion);
                    cmd.Parameters.AddWithValue("nombre", oPago.nombre);
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
        public bool Editar(PagoModel oPago)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPago", conexion);
                    cmd.Parameters.AddWithValue("idPago", oPago.idPago);
                    cmd.Parameters.AddWithValue("nombre", oPago.nombre);
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
                    SqlCommand cmd = new SqlCommand("sp_BorraPago", conexion);
                    cmd.Parameters.AddWithValue("idPago", id);
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
