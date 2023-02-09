using Campañas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Campañas.Datos
{
    public class MovimientoDatos{
        public List<MovimientoModel> Listar()
        {
            var oLista = new List<MovimientoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaMovimiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new MovimientoModel()
                        {
                            idMovimiento = Convert.ToInt32(dr["idMovimiento"]),
                            factura = dr["factura"].ToString(),
                            notaCredito = dr["notaCredito"].ToString(),
                            mes = dr["mes"].ToString(),
                            concepto = dr["concepto"].ToString(),
                            gasto = Convert.ToDouble(dr["gasto"]),
                            impuestos = Convert.ToDouble(dr["impuestos"]),
                            tipo = dr["tipo"].ToString(),
                            fecha = dr["fecha"].ToString(),
                            idMarca = dr["idMarca"].ToString(),
                            idPago = dr["idPago"].ToString(),
                            idEmpleado = dr["idEmpleado"].ToString()
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }

        public MovimientoModel Obtener(int id)
        {
            var oModelo = new MovimientoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaMovimiento", conexion);
                cmd.Parameters.AddWithValue("idMov", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oModelo.idMovimiento = Convert.ToInt32(dr["idMovimiento"]);
                        oModelo.factura = dr["factura"].ToString();
                        oModelo.notaCredito = dr["notaCredito"].ToString();
                        oModelo.mes = dr["mes"].ToString();
                        oModelo.concepto = dr["concepto"].ToString();
                        oModelo.gasto = Convert.ToDouble(dr["gasto"]);
                        oModelo.impuestos = Convert.ToDouble(dr["impuestos"]);
                        oModelo.tipo = dr["tipo"].ToString();
                        oModelo.fecha = dr["fecha"].ToString();
                        oModelo.idMarca = dr["idMarca"].ToString();
                        oModelo.idPago = dr["idPago"].ToString();
                        oModelo.idEmpleado = dr["idEmpleado"].ToString();

                    }
                }
                conexion.Close();
            }
            return oModelo;
        }

        public bool Guardar(MovimientoModel oMovimiento)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaMovimiento", conexion);
                    cmd.Parameters.AddWithValue("factura", oMovimiento.factura);
                    cmd.Parameters.AddWithValue("notaCredito", oMovimiento.notaCredito);
                    cmd.Parameters.AddWithValue("mes", oMovimiento.mes);
                    cmd.Parameters.AddWithValue("concepto", oMovimiento.concepto);
                    cmd.Parameters.AddWithValue("gasto", oMovimiento.gasto);
                    cmd.Parameters.AddWithValue("impuestos", oMovimiento.impuestos);
                    cmd.Parameters.AddWithValue("tipo", oMovimiento.tipo);
                    cmd.Parameters.AddWithValue("fecha", oMovimiento.fecha);
                    cmd.Parameters.AddWithValue("idMarca", oMovimiento.idMarca);
                    cmd.Parameters.AddWithValue("idPago", oMovimiento.idPago);
                    cmd.Parameters.AddWithValue("idEmpleado", oMovimiento.idEmpleado);
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
        public bool Editar(MovimientoModel oMovimiento)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarMovimiento", conexion);
                    cmd.Parameters.AddWithValue("idMovimiento", oMovimiento.idMovimiento);
                    cmd.Parameters.AddWithValue("factura", oMovimiento.factura);
                    cmd.Parameters.AddWithValue("notaCredito", oMovimiento.notaCredito);
                    cmd.Parameters.AddWithValue("mes", oMovimiento.mes);
                    cmd.Parameters.AddWithValue("concepto", oMovimiento.concepto);
                    cmd.Parameters.AddWithValue("gasto", oMovimiento.gasto);
                    cmd.Parameters.AddWithValue("impuestos", oMovimiento.impuestos);
                    cmd.Parameters.AddWithValue("tipo", oMovimiento.tipo);
                    cmd.Parameters.AddWithValue("fecha", oMovimiento.fecha);
                    cmd.Parameters.AddWithValue("idMarca", oMovimiento.idMarca);
                    cmd.Parameters.AddWithValue("idPago", oMovimiento.idPago);
                    cmd.Parameters.AddWithValue("idEmpleado", oMovimiento.idEmpleado);
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
                    SqlCommand cmd = new SqlCommand("sp_BorraMovimiento", conexion);
                    cmd.Parameters.AddWithValue("idMovimiento", id);
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
