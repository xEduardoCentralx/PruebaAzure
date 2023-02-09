//Vamos a importar la carpeta de models para trabajar con la BD
using Campañas.Models;
//Tambien vamos a el paquete de SQL que hemos descargado
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Campañas.Datos
{
    public class EmpleadoDatos
    {

        //Creamos una lista para que nos pueda mostrar los datos que ha tradio del modelo EmpleadoModel
        public List<Empleado> Listar(){
            //Creamos un objeto para hacer referencia a nuestra lista
            var oLista = new List<Empleado>();
            /*Hcaemos referencia con la variable cn a nuestra cadena de conexion que se
             encuentra en la carpeta de Datos/Conexion*/
            var cn = new Conexion();
            //Hcaemos uso de la conexion a la base de datos y nos retorna la cadena SQL
            using (var conexion = new SqlConnection(cn.getCadenaSQL())){
                //Abrimos la cadena de conexion
                conexion.Open();
                //Usamos SqlCommand para hacer la ejecucion del procedimiento almacenado
                SqlCommand cmd = new SqlCommand("sp_ConsultaEmpleado", conexion);
                //Con el CommandType.StoredProcedure le indicamos al cmd que vamos a ejecutar un procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Vamos a leer todos los datos que ha encontrado en la BD
                using (var dr = cmd.ExecuteReader())
                {
                    //Con el While hacemos la lectura de todos los registros que traemos con la consulta
                    while (dr.Read())
                    {
                        //Agregamos los registros traidos
                        oLista.Add(new Empleado()
                        {
                            //Convertimos nuestro id a un entero
                            IdEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            /*Traemos el dato que se haya obtenido de la columna nombre y lo pasamos a string.
                            Haremos eso con todas las columnas de la tabla Empleado*/
                            Nombre = dr["nombre"].ToString(),
                            ApPaterno = dr["apPaterno"].ToString(),
                            ApMaterno = dr["apMaterno"].ToString(),
                            Correo = dr["correo"].ToString(),
                            Contra = dr["contra"].ToString(),
                            Rol = dr["rol"].ToString(),
                        });
                    }
                }
                conexion.Close();
            }
            return oLista;
        }
        public Empleado Obtener(int id){
            //Creamos un objeto para hacer referencia a nuestra lista
            var oModelo= new Empleado();
            /*Hacemos referencia con la variable cn a nuestra cadena de conexion que se
             encuentra en la carpeta de Datos/Conexion*/
            var cn = new Conexion();
            //Hacemos uso de la conexion a la base de datos y nos retorna la cadena SQL
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //Abrimos la cadena de conexion
                conexion.Open();
                //Usamos SqlCommand para hacer la consulta a la base de datos y llamamos a la conexion
                SqlCommand cmd = new SqlCommand("sp_BuscaEmpleado", conexion);
                //Agregamos el valor del id
                cmd.Parameters.AddWithValue("idEmpleado", id);
                //Con el CommandType.StoredProcedure le indicamos al cmd que vamos a ejecutar un procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Vamos a leer todos los datos que ha encontrado en la BD
                using (var dr = cmd.ExecuteReader())
                {
                    //Con el While hacemos la lectura de todos los registros que traemos con la consulta
                    while (dr.Read())
                    {
                        //Convertimos nuestro id a un entero
                        oModelo.IdEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                        /*Traemos el dato que se haya obtenido de la columna nombre y lo pasamos a string.
                        Haremos eso con todas las columnas de la tabla Empleado*/
                        oModelo.Nombre = dr["nombre"].ToString();
                        oModelo.ApPaterno = dr["apPaterno"].ToString();
                        oModelo.ApMaterno = dr["apMaterno"].ToString();
                        oModelo.Correo = dr["correo"].ToString();
                        oModelo.Contra = dr["contra"].ToString();
                        oModelo.Rol = dr["rol"].ToString();
                        
                    }
                }
                conexion.Close();
            }
            return oModelo;
        }
        
        public bool Guardar(Empleado oEmpleado){
            bool respuesta;

            try{
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL())){

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregaEmpleado", conexion);
                cmd.Parameters.AddWithValue("nombre", oEmpleado.Nombre);
                cmd.Parameters.AddWithValue("apPaterno", oEmpleado.ApPaterno);
                cmd.Parameters.AddWithValue("apMaterno", oEmpleado.ApMaterno);
                cmd.Parameters.AddWithValue("correo", oEmpleado.Correo);
                cmd.Parameters.AddWithValue("contra", oEmpleado.Contra);
                cmd.Parameters.AddWithValue("rol", oEmpleado.Rol);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conexion.Close();
            } 
            respuesta = true;

            } catch (Exception e){
                string error = e.Message;
                respuesta=false;
            }
        return respuesta;
        }

        public bool Editar(Empleado oEmpleado){
            bool respuesta;

            try{
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL())){

                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                cmd.Parameters.AddWithValue("idEmpleado", oEmpleado.IdEmpleado);
                cmd.Parameters.AddWithValue("nombre", oEmpleado.Nombre);
                cmd.Parameters.AddWithValue("apPaterno", oEmpleado.ApPaterno);
                cmd.Parameters.AddWithValue("apMaterno", oEmpleado.ApMaterno);
                cmd.Parameters.AddWithValue("correo", oEmpleado.Correo);
                cmd.Parameters.AddWithValue("contra", oEmpleado.Contra);
                cmd.Parameters.AddWithValue("rol", oEmpleado.Rol);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conexion.Close();
            } 
            respuesta = true;

            } catch (Exception e){
                string error = e.Message;
                respuesta=false;
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
                    SqlCommand cmd = new SqlCommand("sp_Borra", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", id);
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
