//Lo primero que debemos hacer es agregar el paquete de SQLcLient
using System.Data.SqlClient;
namespace Campañas.Datos
{
    public class Conexion{
        //Se crea esta variable para almacenar la cadena de conexion
        private string cadenaSQL = string.Empty;
        //Tenemos el constructor para la clase, se debe llamar de igual manera que la clase
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
           //Con esta cadenaSQL obtenemos el valor de nuestra conexion a la base de datos
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        //Creamos este metodo para poder devolver la cadena se conexion

        public string getCadenaSQL() { return cadenaSQL; }
    }
}
