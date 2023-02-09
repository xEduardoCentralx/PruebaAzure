using Campañas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Campañas.Datos
{
    public class ContratoDatos
    {
        public List<PContratoModel> Listar()
        {
            var oLista = new List<PContratoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ConsultaContrato", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oLista.Add(new PContratoModel()
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
                conexion.Close();
            }
            return oLista;
        }


        public PContratoModel Obtener(int id)
        {
            var oModelo = new PContratoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscaContratoHerramienta", conexion);
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
                conexion.Close();
            }
            return oModelo;
        }

        public bool Guardar(PContratoModel oContrato)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaContratoHerramienta", conexion);
                    cmd.Parameters.AddWithValue("Herramienta", oContrato.Herramienta);
                    cmd.Parameters.AddWithValue("Enero", oContrato.Enero);
                    cmd.Parameters.AddWithValue("Febrero", oContrato.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", oContrato.Marzo);
                    cmd.Parameters.AddWithValue("Abril", oContrato.Abril);
                    cmd.Parameters.AddWithValue("Mayo", oContrato.Mayo);
                    cmd.Parameters.AddWithValue("Junio", oContrato.Junio);
                    cmd.Parameters.AddWithValue("Julio", oContrato.Julio);
                    cmd.Parameters.AddWithValue("Agosto", oContrato.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", oContrato.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", oContrato.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", oContrato.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", oContrato.Diciembre);
                    cmd.Parameters.AddWithValue("SEvento", oContrato.SEvento);
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

        public bool Editar(PContratoModel oContrato)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarContato", conexion);
                    cmd.Parameters.AddWithValue("idHerramienta", oContrato.idHerramienta);
                    cmd.Parameters.AddWithValue("Herramienta", oContrato.Herramienta);
                    cmd.Parameters.AddWithValue("Enero", oContrato.Enero);
                    cmd.Parameters.AddWithValue("Febrero", oContrato.Febrero);
                    cmd.Parameters.AddWithValue("Marzo", oContrato.Marzo);
                    cmd.Parameters.AddWithValue("Abril", oContrato.Abril);
                    cmd.Parameters.AddWithValue("Mayo", oContrato.Mayo);
                    cmd.Parameters.AddWithValue("Junio", oContrato.Junio);
                    cmd.Parameters.AddWithValue("Julio", oContrato.Julio);
                    cmd.Parameters.AddWithValue("Agosto", oContrato.Agosto);
                    cmd.Parameters.AddWithValue("Septiembre", oContrato.Septiembre);
                    cmd.Parameters.AddWithValue("Octubre", oContrato.Octubre);
                    cmd.Parameters.AddWithValue("Noviembre", oContrato.Noviembre);
                    cmd.Parameters.AddWithValue("Diciembre", oContrato.Diciembre);
                    cmd.Parameters.AddWithValue("SEvento", oContrato.SEvento);
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
                    SqlCommand cmd = new SqlCommand("sp_BorraContrato", conexion);
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
