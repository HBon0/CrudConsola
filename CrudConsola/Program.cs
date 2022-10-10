using CrudConsola.AccesoADatos;
using CrudConsola.Models;
using System;


namespace CrudConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos a un Crud en Consola!");
            CervezaDAL cervezaBD = new CervezaDAL(); //Creamos un objeto de la clase CervezaBD
                                                     //para luego usar sus metodos. 
            CervezaEN cerveza = new CervezaEN(); //Creamos un objeto de cerveza
                                                 //para luego llenarlo. 

            RolDAL rolDal = new RolDAL();
            Rol rol = new Rol();

            int respuesta = 0; //Variable para almacenar respuesta del usuario. 
            string cadena = ""; //varaible para leer lo escrito en consola. 

            do
            {
                Console.WriteLine("Escoga la opcion a realizar. \n 1. Obtener Todos. " +
                    "\n 2. Obtener por ID. \n 3.Crear una Cerveza. \n 4.Modificar una cerveza." +
                    " \n 5 Borrar una cerveza. \n 6 Salir."); //Creamos un console con las opciones a elegir. 
                cadena = Console.ReadLine(); //obtenemos lo escrito en consola. 
                respuesta = Convert.ToInt32(cadena); //convertimos a int la cadena. 

                switch (respuesta) //Mediante un Switch llamaremos los metodos dependiendo
                {                   //la opcion escogida por el usuario.
                    case 1:
                        GetRoles();
                         break;

                    case 2:
                        AddRol();
                        break;

                    case 3:
                        UpadteRol();
                         break;

                    case 4:
                        Editar();
                        break;
                    case 5:
                        DeleteRol();
                        break;
                }

                if (respuesta != 6) //Si el usuario no escogio Salir al principio le preguntamos
                {                      // Si desea seguir con el programa. 

                    Console.WriteLine("\n Desea continuar realizando " +
                    "consultas a la Base De Datos? \n 1. SI. \n 2.NO.");
                    cadena = Console.ReadLine();
                    respuesta = Convert.ToInt32(cadena); 

                    if (respuesta == 2) // Si el usuario escoge No, cerramos el programa. 
                    {
                        Console.Clear(); //Limpiamos la consola. 
                        break; //Rompemos el Ciclo. 
                    }

                }
                Console.Clear(); //Limpiamos consola.
            } while (respuesta !=6); //Cerramos el 


            // Metodos para hacer CRUD 
            void ObtenerTodos()
            {
                var cervezas = cervezaBD.GetTodos(); //Primeramente creamos una var llamada cervezas
                                                     //Esta almacenara todos los registro que trea el metodo. 
                foreach (var item in cervezas)
                {
                    Console.WriteLine("\n" + item.Id + " " +  item.nombre + " " +
                        item.marca); //Recorremos cada uno de los registros almacenados
                                                           //En la variable
                }
            }

            void ObtenerID()
            {
                int id = 0;
                Console.WriteLine("\n Ingrese el Id del registro a buscar: ");
                cadena = Console.ReadLine();
                id = Convert.ToInt32(cadena); 

                cerveza = cervezaBD.GetID(id); //Llamamos al metodo obtenerID.
                                             //Para ello le enviamose el ID a buscar. 
                                            //El cual almacenara la cerveza en la variable
                                            //cerveza. 

                Console.WriteLine("\n" + cerveza.Id + " " + cerveza.nombre + " " + cerveza.marca ); 
                //Mostramos en pantalla la cerveza obtenida. 
            }

            void Crear()
            {
                int valor = 0;
                Console.WriteLine("\n Ingrese el nombre de la Cerveza: ");
                cadena = Console.ReadLine(); //Iremos pidiendo los datos de la cerveza usando console.Write
                cerveza.nombre = cadena; //luego agregaremos el valor al atributo del objeto. 
                                         //De este modo iremos llenando el objeto para luego
                                         //enviarselo al metodo.

                Console.WriteLine("\n Ingrese la marca de la Cerveza: ");
                cadena = Console.ReadLine();
                cerveza.marca = cadena;

                Console.WriteLine("\n Ingrese la cantidad de alcohol de la Cerveza: ");
                cadena = Console.ReadLine();
                valor = Convert.ToInt32(cadena); //cuando sean valores de otro tipo no string
                cerveza.alcohol = valor; //solo hace falta convertirlos y luego agregarlos al objeto. 

                Console.WriteLine("\n Ingrese la cantidad de cervezas: ");
                cadena = Console.ReadLine();
                valor = Convert.ToInt32(cadena);
                cerveza.cantidad = valor;
                
                cervezaBD.Add(cerveza);  //Llamamos el metodo Add y le enviamos 
                                         //el objeto del registro a agregar. 
                
            }

            void Editar() {
                int valor = 0; //Variable para almacenar el valor agregado. 
                int id = 0; //Variable para almacenar el id. 

                Console.WriteLine("\n Ingrese El ID del registro a modicar: ");
                cadena = Console.ReadLine(); //Primeramente almacenamos el Id en una variable. 
                id = Convert.ToInt32(cadena);
 
                Console.WriteLine("\n Ingrese el nombre de la Cerveza: ");
                cadena = Console.ReadLine(); //Iremos pidiendo los datos de la cerveza usando console.Write
                cerveza.nombre = cadena;  //luego agregaremos el valor al atributo del objeto. 
                                          //De este modo iremos llenando el objeto para luego
                                          //enviarselo al metodo. 
                            

                Console.WriteLine("\n Ingrese la marca de la Cerveza: ");
                cadena = Console.ReadLine();
                cerveza.marca = cadena;

                Console.WriteLine("\n Ingrese la cantidad de alcohol de la Cerveza: ");
                cadena = Console.ReadLine();
                valor = Convert.ToInt32(cadena); //cuando tengamos que agregar un valor de otro tipo
                cerveza.alcohol = valor; //solo hace falta convertir y luego agregarlo al objeto. 

                Console.WriteLine("\n Ingrese la cantidad de cervezas: ");
                cadena = Console.ReadLine();
                valor = Convert.ToInt32(cadena);
                cerveza.cantidad = valor;

                cervezaBD.Edit(cerveza, id); //Llamamos el metodo Edit y le agregamos el objeto de cerveza
                                             //Mas el Id del registro a modificar. 

            } 

            void Eliminar()
            {
                int id = 0;

                Console.WriteLine("\n Ingrese El ID del registro a Eliminar: ");
                cadena = Console.ReadLine(); //Pedimos el Id del registro a Eliminar
                id = Convert.ToInt32(cadena); //Luego de convertir la cadena a Int. 

                cervezaBD.Delete(id); //Llamamos el metodo Delete y le enviamos el ID. 
            }

            void GetRoles()
            {
                var roles = rolDal.GetTodos(); //Primeramente creamos una var llamada cervezas
                                                     //Esta almacenara todos los registro que trea el metodo. 
                foreach (var item in roles)
                {
                    Console.WriteLine($" {item.Id} {item.Nombre}"); //Recorremos cada uno de los registros almacenados
                                     //En la variable
                }
            }

            void AddRol()
            {
                Rol pRol = new Rol();
                pRol.Nombre = "TestDapper";
                pRol.Estado = 2;

                rolDal.Add(pRol);
            }

            void UpadteRol()
            {
                Rol pRol = new Rol();
                pRol.Nombre = "TestDapper2";
                pRol.Estado = 2;

                int id = 29;

                rolDal.Update(pRol, id);
            }

            void DeleteRol()
            {
                int id = 29;

                rolDal.Delete(id);
            }
        }
    }
}
