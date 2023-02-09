//Vamos a importar la carpeta de models para trabajar con la BD
using Campañas.Models;
//Tambien vamos a el paquete de SQL que hemos descargado
using System.Data.SqlClient;
using System.Data;
namespace Campañas.Datos
{
    public class ClienteDatos{

        //Creamos una lista para que nos pueda mostrar los datos que ha tradio del modelo EmpleadoModel
        public List<ClienteModel> Listar()
        {
            //Creamos un objeto para hacer referencia a nuestra lista
            var oLista = new List<ClienteModel>();
            /*Hcaemos referencia con la variable cn a nuestra cadena de conexion que se
             encuentra en la carpeta de Datos/Conexion*/
            var cn = new Conexion();
            //Hcaemos uso de la conexion a la base de datos y nos retorna la cadena SQL
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //Abrimos la cadena de conexion
                conexion.Open();
                //Usamos SqlCommand para hacer la ejecucion del procedimiento almacenado
                SqlCommand cmd = new SqlCommand("sp_ConsultaCliente", conexion);
                //Con el CommandType.StoredProcedure le indicamos al cmd que vamos a ejecutar un procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Vamos a leer todos los datos que ha encontrado en la BD
                using (var dr = cmd.ExecuteReader())
                {
                    //Con el While hacemos la lectura de todos los registros que traemos con la consulta
                    while (dr.Read())
                    {
                        //Agregamos los registros traidos
                        oLista.Add(new ClienteModel()
                        {
                            //Convertimos nuestro id a un entero
                            idCliente = Convert.ToInt32(dr["idCliente"]),
                            /*Traemos el dato que se haya obtenido de la columna nombre y lo pasamos a string.
                            Haremos eso con todas las columnas de la tabla Empleado*/
                           nombre = dr["nombre"].ToString(),
                           apPaterno = dr["apPaterno"].ToString(),
                           apMaterno = dr["apMaterno"].ToString(),
                           empresa = dr["empresa"].ToString(),
                           tipo = dr["tipo"].ToString(),
                           fecha = dr["fecha"].ToString(),
                           idEmpleado = Convert.ToInt32(dr["idEmpleado"])
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }

        public ClienteModel Obtener(int id)
        {
            //Creamos un objeto para hacer referencia a nuestra lista
            var oModelo = new ClienteModel();
            /*Hacemos referencia con la variable cn a nuestra cadena de conexion que se
             encuentra en la carpeta de Datos/Conexion*/
            var cn = new Conexion();
            //Hacemos uso de la conexion a la base de datos y nos retorna la cadena SQL
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //Abrimos la cadena de conexion
                conexion.Open();
                //Usamos SqlCommand para hacer la consulta a la base de datos y llamamos a la conexion
                SqlCommand cmd = new SqlCommand("sp_BuscaCliente", conexion);
                //Agregamos el valor del id
                cmd.Parameters.AddWithValue("idCliente", id);
                //Con el CommandType.StoredProcedure le indicamos al cmd que vamos a ejecutar un procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Vamos a leer todos los datos que ha encontrado en la BD
                using (var dr = cmd.ExecuteReader())
                {
                    //Con el While hacemos la lectura de todos los registros que traemos con la consulta
                    while (dr.Read())
                    {
                        //Convertimos nuestro id a un entero
                        oModelo.idCliente = Convert.ToInt32(dr["idCliente"]);
                        /*Traemos el dato que se haya obtenido de la columna nombre y lo pasamos a string.
                        Haremos eso con todas las columnas de la tabla Empleado*/
                        oModelo.nombre = dr["nombre"].ToString();
                        oModelo.apPaterno = dr["apPaterno"].ToString();
                        oModelo.apMaterno = dr["apMaterno"].ToString();
                        oModelo.empresa = dr["empresa"].ToString();
                        oModelo.tipo = dr["tipo"].ToString();
                        oModelo.fecha = dr["fecha"].ToString();
                        oModelo.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                    }
                }
                conexion.Close();
            }
            return oModelo;
        }

        public bool Guardar(ClienteModel oCliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregaCliente", conexion);
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("apPaterno", oCliente.apPaterno);
                    cmd.Parameters.AddWithValue("apMaterno", oCliente.apMaterno);
                    cmd.Parameters.AddWithValue("empresa", oCliente.empresa);
                    cmd.Parameters.AddWithValue("tipo", oCliente.tipo);
                    cmd.Parameters.AddWithValue("fecha", oCliente.fecha);
                    cmd.Parameters.AddWithValue("idEmpleado", oCliente.idEmpleado);
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

        public bool Editar(ClienteModel oCliente)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditaCliente", conexion);
                    cmd.Parameters.AddWithValue("idCliente", oCliente.idCliente);
                    cmd.Parameters.AddWithValue("nombre", oCliente.nombre);
                    cmd.Parameters.AddWithValue("apPaterno", oCliente.apPaterno);
                    cmd.Parameters.AddWithValue("apMaterno", oCliente.apMaterno);
                    cmd.Parameters.AddWithValue("empresa", oCliente.empresa);
                    cmd.Parameters.AddWithValue("tipo", oCliente.tipo);
                    cmd.Parameters.AddWithValue("fecha", oCliente.fecha);
                    cmd.Parameters.AddWithValue("idEmpleado", oCliente.idEmpleado);
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
                    SqlCommand cmd = new SqlCommand("sp_BorraCliente", conexion);
                    cmd.Parameters.AddWithValue("idCliente", id);
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
