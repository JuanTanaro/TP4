using System;
using System.Collections.Generic;
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

                var persona = Alumno.Seleccionar();
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
                Console.WriteLine("3 - Contador Publico");
                Console.WriteLine("4 - Actuario en administracion");
                Console.WriteLine("5 - Actuario en economia");
                Console.WriteLine("6 - Administracion de empresas");

                var eleccionCarrera = Console.ReadLine();

                switch (eleccionCarrera)
                {
                    case "1":
                        MostrarMaterias(eleccionCarrera, CodigoPersona);
                        break;
                    case "2":
                        MostrarMaterias(eleccionCarrera, CodigoPersona);
                        break;
                    case "3":
                        MostrarMaterias(eleccionCarrera, CodigoPersona);
                        break;
                        //.....
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú");
                        break;
                }

            } while (!salir);
        }

        private static void MostrarMaterias(string eleccionCarrera, int CodigoPersona)
        {
            if (eleccionCarrera == "1")
            {
                Economia.MostrarDatos();
                Aprobada(eleccionCarrera, CodigoPersona);
            }
            else if (eleccionCarrera == "2")
            {
                Sistemas.MostrarDatos();
                Aprobada(eleccionCarrera, CodigoPersona);
            }
            else if (eleccionCarrera == "3")
            {
                Contador.MostrarDatos();
                Aprobada(eleccionCarrera, CodigoPersona);
            }
        }

        private static void Aprobada(string eleccionCarrera, int CodigoPersona)
        {
            Console.WriteLine("\nSeleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");

            if (eleccionCarrera == "1")
            {
                var materia = Economia.Seleccionar();
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona);
                }
                materia.Mostrar();
                Console.WriteLine($"Marca aprobada la materia {materia.CodigoMateria}. Está usted seguro? S/N\n");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.S)
                {
                    MateriasAprobadasPorAlumno.Agregar(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                }

                OtraAprobada(eleccionCarrera, CodigoPersona);
            }
        }

        private static void OtraAprobada(string eleccionCarrera, int CodigoPersona)
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
                        Aprobada(eleccionCarrera, CodigoPersona);
                        break;
                    case "2":
                        MateriasAprobadasPorAlumno.MostrarDatos(CodigoPersona);
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
            Asignacion.Agregar(inscripcion);
            Asignacion.MostrarDatos();
        }

    }
}
