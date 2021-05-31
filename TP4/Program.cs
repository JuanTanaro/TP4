using System;
using System.IO;
using System.Threading;

namespace TP4
{
    internal class Program
    {
        //Problemas:

        static void Main(string[] args)
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("-------------");

                // Iniciacion del usuario. 
                BuscoRegistro();

                // Seleccionamos la carrera
                Console.WriteLine("Seleccione su carrera, para luego anotarse a las materias");
                Console.WriteLine("1 - Economia");
                Console.WriteLine("2 - Sistemas");
                Console.WriteLine("3 - Administracion de empresas");
                Console.WriteLine("4 - Actuario en administracion");
                Console.WriteLine("5 - Actuario en economia");
                Console.WriteLine("6 - Contador Publico");

                var eleccionCarrera = Console.ReadLine();

                switch (eleccionCarrera)
                {
                    case "1":
                        MostrarMaterias(eleccionCarrera);
                        Baja(eleccionCarrera);
                        break;
                    case "2":
                        MostrarMaterias(eleccionCarrera);
                        Baja(eleccionCarrera);
                        break;
                    case "3":
                        MostrarMaterias(eleccionCarrera);
                        Baja(eleccionCarrera);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú");
                        break;
                }

            } while (!salir);
        }

        private static void BuscoRegistro()
        {
            var persona = Persona.Seleccionar();
            if (persona == null)
            {
                BuscoRegistro();
            }
            persona?.Mostrar();
        }

        private static void MostrarMaterias(string eleccionCarrera)
        {
            if (eleccionCarrera == "1")
            {
                Economia.MostrarDatos();
            }
            else if (eleccionCarrera == "2")
            {
                Sistemas.MostrarDatos();
            }
            else if (eleccionCarrera == "3")
            {
                Contador.MostrarDatos();
            }
        }

        private static void Baja(string eleccionCarrera)
        {
            Console.WriteLine("Seleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");

            //ANALIZAR
            //Aca intentaria crear un txt de alumno con las materias que tiene cursadas

            //Luego de eso, procederia a anotarse, las restricciones posibles serian:
            //      las correlatividades
            //      o en caso de que .Count(materias) < 4, libre eleccion

            if (eleccionCarrera == "1")
            {
                var materia = Economia.Seleccionar();
                if (materia == null)
                {
                    return;
                }
                materia.Mostrar();
                Console.WriteLine($"Marca aprobada la materia {materia.CodigoMateria}. Está ud. seguro? S/N\n");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.S)
                {
                    Economia.Baja(materia);
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                }

                EliminarMateria(eleccionCarrera);
            }

            else if (eleccionCarrera == "2")
            {
                var materia = Sistemas.Seleccionar();
                if (materia == null)
                {
                    return;
                }
                materia.Mostrar();
                Console.WriteLine($"Marca aprobada la materia {materia.CodigoMateria}. Está ud. seguro? S/N\n");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.S)
                {
                    Sistemas.Baja(materia);
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                }

                EliminarMateria(eleccionCarrera);
            }

            else if (eleccionCarrera == "3")
            {
                var materia = Contador.Seleccionar();
                if (materia == null)
                {
                    return;
                }
                materia.Mostrar();
                Console.WriteLine($"Marca aprobada la materia {materia.CodigoMateria}. Está ud. seguro? S/N\n");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.S)
                {
                    Contador.Baja(materia);
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                }

                EliminarMateria(eleccionCarrera);
            }
        }

        private static void EliminarMateria(string eleccionCarrera)
        {
            bool salir = false;
            do
            {
                Console.WriteLine("¿Tiene otra materia aprobada?");
                Console.WriteLine("1 - SI");
                Console.WriteLine("2 - NO");

                var respuesta = Console.ReadLine();

                switch (respuesta)
                {
                    case "1":
                        Baja(eleccionCarrera);
                        break;
                    case "2":
                        MostrarMaterias(eleccionCarrera);
                        InscripcionMaterias();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú");
                        break;
                }
            } while (!salir);
        }

        private static void InscripcionMaterias()
        {
            var inscripcion = Asignacion.Asignar();
            Inscripcion.Agregar(inscripcion);
        }

    }
}
