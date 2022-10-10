using CrudConsola.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudConsola.AccesoADatos
{
    public class CervezaDAL
    {
        private string connectionString
        = "Data Source=localhost;Initial Catalog=Pruebasv1;"
            + "Integrated Security=True"; //Creamos nuestro String de conexion a nuestra base de datos. 

        public List<CervezaEN> GetTodos() //Creamos un metodo llamado GetTodos para
        {                                 // obtener todas las cervezas en la base de Datos.
            var cervezas = new List<CervezaEN>(); // Creamos una list de Cerveza, que es
                                                  // donde se almacenaran todas las Cervezas
                                                  //que traeremos de la base de datos.

            string query = "select  nombre, marca, alcohol, cantidad, id " + 
                "from Cerveza"; //Creamos una variable string que es dnode estara almacenada la consulta.

            using (var connection = new SqlConnection(connectionString))
            {                                                   //Usamos un using para crear la conexion a la base de datos.    
                                                                //Ya que de esta forma la conexion solo sera abierta cuando 
                                                                // el using sea utilizado. 

                var command = new SqlCommand(query, connection); //Creamos un objeto de la Clase SqlCommand
                                                                 //la cual espera dos parametros, uno es la consulta y
                                                                 //el otro la conecion. 
                                                                 //Esta clase nos sirve para mandar consultas.
                connection.Open(); //Abrimos la conexion a la base de Datos.

                SqlDataReader reader = command.ExecuteReader(); //SqlReader lo que hace es leer el resultado uno a uno. 
                while (reader.Read()) //Mientras reader este leyendo un registro hara lo siguiente. 
                {
                    CervezaEN cerveza = new CervezaEN(); //creamos un objeto de tipo Cerveza. 
                    cerveza.nombre = reader.GetString(0); //Procedemos a llenar los campos del objeto cerveza
                    cerveza.marca = reader.GetString(1); //Los llenamos en orden segun esten los campos en el query
                    cerveza.alcohol = reader.GetInt32(2); //De igual manera los parseamos al tipo de Dato que espera el objeto.
                    cerveza.cantidad = reader.GetInt32(3);
                    cerveza.Id = reader.GetInt32(4);
                    cervezas.Add(cerveza); //Agregamos el objeto a la Lista Cervezas declarada arriba.
                }
                reader.Close(); //Cerramos el reader, por que no tiene nada que leer. 
                connection.Close(); //Cerramos la conexion a la base de Datos.
            }
            return cervezas;
        }

        public CervezaEN GetID (int id) 
        {   //Creamos un metodo que devuele un objeto de la clase Cerveza y que espera
            //un Ind como parametro, dicho Int nos servira para buscar el ID. 


            var cerveza = new CervezaEN(); //creamos un objeto de tipo Cerveza. 

            string query = "select id, nombre, marca, cantidad, alcohol from cerveza where id=@id"; 
            //Este query nos servira para hacer la consulta a la base de Datos. 

            using (var connection = new SqlConnection(connectionString)) //Usamos un using para crear la conexion
            {                                                            //a la base de datos. Ya que de esta forma
                                                                         //la conexion solo sera abierta cuando                                  
                                                                         // el using sea utilizado.

                var command = new SqlCommand(query, connection); //Creamos un objeto de la Clase SqlCommand
                                                                 //la cual espera dos parametros, uno es la consulta y
                                                                 //el otro la conecion. 
                command.Parameters.AddWithValue("@id", id); //Agregamos el Id como parametro a la consulata del command. 

                connection.Open(); //Abrimos la conexion a la base de Datos.

                SqlDataReader reader = command.ExecuteReader(); //SqlReader lo que hace es leer el resultado uno a uno. 
                while (reader.Read()) //Mientras reader este leyendo un registro hara lo siguiente. 
                {
                    cerveza.Id = reader.GetInt32(0);
                    cerveza.nombre = reader.GetString(1); //Procedemos a llenar los campos del objeto cerveza
                    cerveza.marca = reader.GetString(2); //Los llenamos en orden segun esten los campos en el query
                    cerveza.alcohol = reader.GetInt32(4); //De igual manera los parseamos al tipo de Dato que espera el objeto.
                    cerveza.cantidad = reader.GetInt32(3);
                    
                }
                reader.Close(); //Cerramos el reader, por que no tiene nada que leer. 
                connection.Close(); //Cerramos la conexion a la base de Datos.
            }

            return cerveza; //Retornamos el objeto cerveza luego de haberla encontrado 
        }

        public void Add(CervezaEN cerveza)
        {
            string query = "insert into Cerveza " +
                "(nombre, marca, alcohol, cantidad) " + //Creamos el query que sera la consulta para 
                 "values (@nombre, @marca, @alcohol, @cantidad)"; //hacer una insersion de
                                                                  //datos en la tabla Cervezas

            using (var connection = new SqlConnection(connectionString)) //Creamos la conexion
            {                                                       //usando la clase SqlConection.                                                         

                var command = new SqlCommand(query, connection); //Hacemos uso de la clase commanda, para 
                                                                 //realizar la consulta. 

                command.Parameters.AddWithValue("@nombre", cerveza.nombre); //Agregamos los parametro al comando
                command.Parameters.AddWithValue("@marca", cerveza.marca); //Para ello indicamos que campo sera
                command.Parameters.AddWithValue("@alcohol", cerveza.alcohol); //Luego le indicamos que es igual 
                command.Parameters.AddWithValue("@cantidad", cerveza.cantidad); //a un atributo del objeto

                connection.Open(); //Abrimos la conexion a la base de datos.
                command.ExecuteNonQuery(); //Esto ejecuta una transaccion SQl, es decir hace la consulta
                connection.Close(); //Cerramos la conexion a la base.
            }


        }

        public void Edit(CervezaEN cerveza, int id)
        {
            string query = "update cerveza set nombre=@nombre, " +
                "marca=@marca, alcohol=@alcohol, cantidad=@cantidad " + 
                "where id=@id"; //Creamos la consulta en el query, de modifar un registro
                                //Donde sea igual al Id que le enviaremos. 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection); //Como ya sabemos el commanda espera, la consulta
                                                                 //y la conexion a la base.

                command.Parameters.AddWithValue("@nombre", cerveza.nombre); //Agregamos los parametros 
                command.Parameters.AddWithValue("@marca", cerveza.marca); //a los campos de la consulta
                command.Parameters.AddWithValue("@alcohol", cerveza.alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.cantidad);
                command.Parameters.AddWithValue("@id", id); //Agregamos el Id del registro a modificar,
                                                            //este id lo obtendremos
                                                            //del int que espera el metodo.

                connection.Open(); //Abrimos conexion
                command.ExecuteNonQuery(); //Ejecutamos la transaccion.
                connection.Close(); //Cerramos la conexion. 
            }
        }

        public void Delete(int id)
        {
            string query = "delete from cerveza where id=@id"; //Creamos la consulta para Eliminar un registro,
                                                               //donde el registro tenga
                                                               //como Id el parametro que le agregaremos

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection); //Como ya sabemos el commanda espera,
                                                                 //la consulta y la conexion a la base.
                command.Parameters.AddWithValue("@id", id); //Agregamos al campo el parametro
                                                            //id que espera el metodo.

                connection.Open(); //Abrimos conexon a al base. 
                command.ExecuteNonQuery(); //Ejecutamose la transaccion. 
                connection.Close(); //Cerramos la conexion. 
            }

        }
    }
}
