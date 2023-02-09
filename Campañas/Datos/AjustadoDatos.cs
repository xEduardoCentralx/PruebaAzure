using Campañas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Campañas.Datos
{
    public class AjustadoDatos
    {
        public List<PAjustadoModel> Listar()
        {
            
            var oLista = new List<PAjustadoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaAjustado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oLista.Add(new PAjustadoModel()
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


        public PAjustadoModel Obtener(int id)
        {
            var oModelo = new PAjustadoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaHerramienta", conexion);
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


        public bool Guardar(PAjustadoModel oAjustado)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaHerramienta", conexion);
                    cmd.Parameters.AddWithValue("Herramienta",oAjustado.Herramienta);
                    cmd.Parameters.AddWithValue("Enero", oAjustado.Enero);
                    cmd.Parameters.AddWithValue("Febrero", oAjustado.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", oAjustado.Marzo);
                    cmd.Parameters.AddWithValue("Abril", oAjustado.Abril);
                    cmd.Parameters.AddWithValue("Mayo", oAjustado.Mayo);
                    cmd.Parameters.AddWithValue("Junio", oAjustado.Junio);
                    cmd.Parameters.AddWithValue("Julio", oAjustado.Julio);
                    cmd.Parameters.AddWithValue("Agosto", oAjustado.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", oAjustado.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", oAjustado.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", oAjustado.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", oAjustado.Diciembre);
                    cmd.Parameters.AddWithValue("SEvento", oAjustado.SEvento);
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

        public bool Editar(PAjustadoModel oAjustado)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                { 
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAjustado", conexion);
                    cmd.Parameters.AddWithValue("idHerramienta", oAjustado.idHerramienta);
                    cmd.Parameters.AddWithValue("Herramienta", oAjustado.Herramienta);
                    cmd.Parameters.AddWithValue("Enero", oAjustado.Enero);
                    cmd.Parameters.AddWithValue("Febrero", oAjustado.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", oAjustado.Marzo);
                    cmd.Parameters.AddWithValue("Abril", oAjustado.Abril);
                    cmd.Parameters.AddWithValue("Mayo", oAjustado.Mayo);
                    cmd.Parameters.AddWithValue("Junio", oAjustado.Junio);
                    cmd.Parameters.AddWithValue("Julio", oAjustado.Julio);
                    cmd.Parameters.AddWithValue("Agosto", oAjustado.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", oAjustado.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", oAjustado.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", oAjustado.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", oAjustado.Diciembre);
                    cmd.Parameters.AddWithValue("SEvento", oAjustado.SEvento);
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
                    SqlCommand cmd = new SqlCommand("sp_BorraAjustado", conexion);
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
