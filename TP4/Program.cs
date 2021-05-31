using System;
using System.IO;
using System.Threading;

namespace TP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
                // Iniciacion del usuario. 
                BuscoRegistro();
        }



        private static void BuscoRegistro()
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("-------------");

                var persona = Persona.Seleccionar();
                if (persona == null)
                {
                    BuscoRegistro();
                }
                persona?.Mostrar();

                int CodigoPersona = persona.NRegistro;

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
                        Baja(eleccionCarrera, CodigoPersona);
                        break;
                    case "2":
                        MostrarMaterias(eleccionCarrera);
                        Baja(eleccionCarrera, CodigoPersona);
                        break;
                    case "3":
                        MostrarMaterias(eleccionCarrera);
                        Baja(eleccionCarrera, CodigoPersona);
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

        private static void Baja(string eleccionCarrera, int CodigoPersona)
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

                EliminarMateria(eleccionCarrera, CodigoPersona)
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

                EliminarMateria(eleccionCarrera, CodigoPersona)
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

                EliminarMateria(eleccionCarrera, CodigoPersona);
            }
        }

        private static void EliminarMateria(string eleccionCarrera, int CodigoPersona)
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
                        Baja(eleccionCarrera, CodigoPersona);
                        break;
                    case "2":
                        MostrarMaterias(eleccionCarrera);
                        InscripcionMaterias(CodigoPersona);
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

        private static void InscripcionMaterias(int CodigoPersona)
        {
            var inscripcion = Asignacion.Asignar(CodigoPersona);
            Inscripcion.Agregar(inscripcion);
            Inscripcion.MostrarDatos();
        }

    }
}
