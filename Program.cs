using System;

using System.IO; // Necesario para StreamWriter, StreamReader y File



namespace Caso_empleado_sem_9

{

    internal class Program

    {

        static int max_emp = 50;

        static string[] nombres = new string[max_emp];

        static string[] correo_emp = new string[max_emp];

        static int cant_emp;



        static public void Titulo()

        {

            Console.WriteLine("*********************************");

            Console.WriteLine("SISTEMA DE EMPLEADOS");

            Console.WriteLine("*********************************");

        }



        static public void Registro_empleado()

        {

            Console.WriteLine("*** REGISTRAR EMPLEADO ****");

            if (cant_emp >= max_emp)

            {

                Console.WriteLine("Alcanza la capacidad maxima de datos");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }

            Console.WriteLine("Ingresar nombres y apellidos: ");

            String nombres_emp = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombres_emp))

            {

                Console.WriteLine("Error, el nombre no puede estar vacio");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }

            string nombres_Mayus = nombres_emp.ToUpper();

            string[] partes = nombres_Mayus.Split(' ');

            string primer_nombre;

            if (partes.Length > 0)

                primer_nombre = partes[0];

            else

                primer_nombre = "usuario";



            string correo = $"{primer_nombre.ToLower()}@upn.edu.pe";

            nombres[cant_emp] = nombres_Mayus;

            correo_emp[cant_emp] = correo;

            cant_emp++;

            Console.WriteLine("¡Empleado registrado con éxito!");

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();

        }



        static public void busca_empleado()

        {

            Console.WriteLine("************Busqueda de empleado***********");

            Console.WriteLine("*******************************************");

            if (cant_emp == 0)

            {

                Console.WriteLine("No hay registro de empleados");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }

            Console.WriteLine("Ingresar nombre o apellido a buscar: ");

            string buscar = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(buscar))

                return;



            bool encontrado = false;

            for (int i = 0; i < cant_emp; i++)

            {

                if (nombres[i].Contains(buscar))

                {

                    Console.WriteLine($"Encontrado -> Nombres: {nombres[i]} | Correo: {correo_emp[i]}");

                    encontrado = true;

                }

            }

            if (!encontrado)

            {

                Console.WriteLine("No se encuentran coincidencias en empleado");

            }

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();

        }



        static public void ordenar()

        {

            if (cant_emp <= 1)

            {

                Console.WriteLine("No hay suficientes registros para ordenar");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }



            for (int i = 0; i < cant_emp - 1; i++)

            {

                for (int j = 0; j < cant_emp - 1 - i; j++)

                {

                    if (string.Compare(nombres[j], nombres[j + 1]) > 0)

                    {

                        string temp_nombres = nombres[j];

                        nombres[j] = nombres[j + 1];

                        nombres[j + 1] = temp_nombres;



                        string temp_correo = correo_emp[j];

                        correo_emp[j] = correo_emp[j + 1];

                        correo_emp[j + 1] = temp_correo;

                    }

                }

            }

            Console.WriteLine("¡Empleados ordenados alfabéticamente con éxito!");

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();

        }



        static public void mostrar()

        {

            Console.WriteLine("*****LISTADO DE EMPLEADOS***********");

            Console.WriteLine("************************************");



            if (cant_emp == 0)

            {

                Console.WriteLine("No hay registros por mostrar");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }

            Console.WriteLine("Nombres y apellidos\t\tCorreo");

            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < cant_emp; i++)

            {

                Console.WriteLine(nombres[i] + "\t\t" + correo_emp[i]);

            }

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();

        }



        static public void Guardar_datos_Archivo()

        {

            Console.WriteLine("********GUARDAR DATOS EN ARCHIVO*******");

            Console.WriteLine("***************************************");

            if (cant_emp == 0)

            {

                Console.WriteLine("No hay registros para guardar");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }

            using (StreamWriter escribir = new StreamWriter("Empleados.txt"))

            {

                for (int i = 0; i < cant_emp; i++)

                {

                    escribir.WriteLine(nombres[i] + "," + correo_emp[i]);

                }

            }

            Console.WriteLine(cant_emp + " empleados guardados en archivo con éxito.");

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();

        }



        static public void Leer_datos_Archivo()

        {

            Console.WriteLine("*****LEER DATOS DE ARCHIVO*********");

            Console.WriteLine("***********************************");

            if (!File.Exists("Empleados.txt"))

            {

                Console.WriteLine("No existe el archivo de empleados");

                Console.WriteLine("\nPresione una tecla para continuar...");

                Console.ReadKey();

                return;

            }



            using (StreamReader lector = new StreamReader("Empleados.txt"))

            {

                string linea;

                cant_emp = 0; // Reiniciamos contador para sobreescribir con los datos leídos

                while ((linea = lector.ReadLine()) != null)

                {

                    string[] partes = linea.Split(',');

                    if (partes.Length == 2 && cant_emp < max_emp)

                    {

                        nombres[cant_emp] = partes[0];

                        correo_emp[cant_emp] = partes[1];

                        cant_emp++;

                    }

                }

            }

            Console.WriteLine("Datos leídos y cargados correctamente desde el archivo.");

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();

        }



        // Método agregado para satisfacer la opción 7 del menú

        static public void Cargar_datos_Archivo()

        {

            Leer_datos_Archivo();

        }



        static void Main(string[] args)

        {

            int opc = 0;

            Titulo();



            while (opc != 8) // Cambiado a 8 porque la opción de salir es 8

            {

                Console.Clear();

                Titulo();

                Console.WriteLine("[1] Registrar empleado");

                Console.WriteLine("[2] Buscar empleado");

                Console.WriteLine("[3] Ordenar alfabeticamente (A-Z)");

                Console.WriteLine("[4] Mostrar empleados");

                Console.WriteLine("[5] Guardar datos en archivo");

                Console.WriteLine("[6] Leer datos de un archivo");

                Console.WriteLine("[7] Cargar datos de un archivo");

                Console.WriteLine("[8] Salir");

                Console.Write("Ingresar opción: ");



                if (!int.TryParse(Console.ReadLine(), out opc))

                {

                    Console.WriteLine("Ingrese un valor númerico válido");

                    Console.ReadKey();

                    continue;

                }



                switch (opc)

                {

                    case 1:

                        Registro_empleado();

                        break;

                    case 2:

                        busca_empleado();

                        break;

                    case 3:

                        ordenar();

                        break;

                    case 4:

                        mostrar();

                        break;

                    case 5:

                        Guardar_datos_Archivo();

                        break;

                    case 6:

                        Leer_datos_Archivo();

                        break;

                    case 7:

                        Cargar_datos_Archivo();

                        break;

                    case 8:

                        Console.WriteLine("Gracias por usar el sistema..!!");

                        break;

                    default:

                        Console.WriteLine("Opción incorrecta, elija del 1 al 8");

                        Console.ReadKey();

                        break;

                }

            }

        }

    }

}