using Campañas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Campañas.Datos
{
    public class DerogadoDatos
    {
        public List<PDerogadoModel> Listar()
        {

            var oLista = new List<PDerogadoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaDerogado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oLista.Add(new PDerogadoModel()
                        {
                            idHerramienta = Convert.ToInt32(dr["idHerramienta"]),
                            Herramienta = dr["Herramienta"].ToString(),
                            Enero = Convert.ToDecimal(dr["Enero"]),
                            Febrero = Convert.ToDecimal(dr["Febrero"]),
                            Marzo = Convert.ToDecimal(dr["Marzo"]),
                            Abril = Convert.ToDecimal(dr["Abril"]),
                            Mayo = Convert.ToDecimal(dr["Mayo"]),
                            Junio = Convert.ToDecimal(dr["Junio"]),
                            Julio = Convert.ToDecimal(dr["Julio"]),
                            Agosto = Convert.ToDecimal(dr["Agosto"]),
                            Septiembre = Convert.ToDecimal(dr["Septiembre"]),
                            Octubre = Convert.ToDecimal(dr["Octubre"]),
                            Noviembre = Convert.ToDecimal(dr["Noviembre"]),
                            Diciembre = Convert.ToDecimal(dr["Diciembre"]),
                            SEvento = Convert.ToDecimal(dr["SEvento"])
                        });
                    }
                }
            }
            return oLista;
        }

        public PDerogadoModel Obtener(int id)
        {
            var oModelo = new PDerogadoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaDerogadoHerramienta", conexion);
                cmd.Parameters.AddWithValue("idHerramienta", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oModelo.idHerramienta = Convert.ToInt32(dr["idHerramienta"]);
                        oModelo.Herramienta = dr["Herramienta"].ToString();
                        oModelo.Enero = Convert.ToDecimal(dr["Enero"]);
                        oModelo.Febrero = Convert.ToDecimal(dr["Febrero"]);
                        oModelo.Marzo = Convert.ToDecimal(dr["Marzo"]);
                        oModelo.Abril = Convert.ToDecimal(dr["Abril"]);
                        oModelo.Mayo = Convert.ToDecimal(dr["Mayo"]);
                        oModelo.Junio = Convert.ToDecimal(dr["Junio"]);
                        oModelo.Julio = Convert.ToDecimal(dr["Julio"]);
                        oModelo.Agosto = Convert.ToDecimal(dr["Agosto"]);
                        oModelo.Septiembre = Convert.ToDecimal(dr["Septiembre"]);
                        oModelo.Octubre = Convert.ToDecimal(dr["Octubre"]);
                        oModelo.Noviembre = Convert.ToDecimal(dr["Noviembre"]);
                        oModelo.Diciembre = Convert.ToDecimal(dr["Diciembre"]);
                        oModelo.SEvento = Convert.ToDecimal(dr["SEvento"]);
                    }

                }
            }
            return oModelo;
        }

        public bool Guardar(PDerogadoModel oDerogado)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaDerogadoHerramienta", conexion);
                    cmd.Parameters.AddWithValue("Herramienta", oDerogado.Herramienta);
                    cmd.Parameters.AddWithValue("Enero", oDerogado.Enero);
                    cmd.Parameters.AddWithValue("Febrero", oDerogado.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", oDerogado.Marzo);
                    cmd.Parameters.AddWithValue("Abril", oDerogado.Abril);
                    cmd.Parameters.AddWithValue("Mayo", oDerogado.Mayo);
                    cmd.Parameters.AddWithValue("Junio", oDerogado.Junio);
                    cmd.Parameters.AddWithValue("Julio", oDerogado.Julio);
                    cmd.Parameters.AddWithValue("Agosto", oDerogado.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", oDerogado.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", oDerogado.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", oDerogado.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", oDerogado.Diciembre);
                    cmd.Parameters.AddWithValue("SEvento", oDerogado.SEvento);
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

        public bool Editar(PDerogadoModel oDerogado)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarDerogado", conexion);
                    cmd.Parameters.AddWithValue("idHerramienta", oDerogado.idHerramienta);
                    cmd.Parameters.AddWithValue("Herramienta", oDerogado.Herramienta);
                    cmd.Parameters.AddWithValue("Enero", oDerogado.Enero);
                    cmd.Parameters.AddWithValue("Febrero", oDerogado.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", oDerogado.Marzo);
                    cmd.Parameters.AddWithValue("Abril", oDerogado.Abril);
                    cmd.Parameters.AddWithValue("Mayo", oDerogado.Mayo);
                    cmd.Parameters.AddWithValue("Junio", oDerogado.Junio);
                    cmd.Parameters.AddWithValue("Julio", oDerogado.Julio);
                    cmd.Parameters.AddWithValue("Agosto", oDerogado.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", oDerogado.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", oDerogado.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", oDerogado.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", oDerogado.Diciembre);
                    cmd.Parameters.AddWithValue("SEvento", oDerogado.SEvento);
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
                    SqlCommand cmd = new SqlCommand("sp_BorraDerogado", conexion);
                    cmd.Parameters.AddWithValue("idHerramienta", id);
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
