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
                Economia.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona);
            }

            if (eleccionCarrera == "2")
            {
                Sistemas.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona);
            }
        }

        private static void Aprobada(string eleccionCarrera, int CodigoPersona)
        {
            Console.WriteLine("\nSeleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");

            if (eleccionCarrera == "1")
            {
                var materia = Economia.Seleccionar(); //te devuelve el codigo de materia en .int
                if(materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona);
                }
                
                materia.Mostrar();
                Console.WriteLine($"Marcaste como aprobada la materia {materia.CodigoMateria}. Está usted seguro? S/N\n");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.S)
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona , materia.CodigoMateria, materia.NombreMateria);
                }

                otraAprobada(eleccionCarrera, CodigoPersona);
            }

            if (eleccionCarrera == "2")
            {
                var materia = Sistemas.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona);
                }

                materia.Mostrar();
                Console.WriteLine($"Marcaste como aprobada la materia {materia.CodigoMateria}. Está usted seguro? S/N\n");
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.S)
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }

                otraAprobada(eleccionCarrera, CodigoPersona);
            }
        }

        private static void otraAprobada(string eleccionCarrera, int CodigoPersona)
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
                        MateriasAprobadasPorAlumno.EscribirAprobadasEnTXT();
                        InscripcionMaterias(CodigoPersona, eleccionCarrera);
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
        
        private static void InscripcionMaterias(int CodigoPersona, string eleccionCarrera)
        {
            Inscripciones.MostrarMateriasDisponibles(eleccionCarrera);
            Console.WriteLine("");
            Console.WriteLine("Escriba el codigo de la primer materia en la cual quiere inscribirse");
                switch (eleccionCarrera)
                {
                case "1":
                    var materiaEcon = Economia.Seleccionar(); //te devuelve el codigo de materia en .int
                    if (materiaEcon == null)
                    {
                        Aprobada(eleccionCarrera, CodigoPersona);
                    }

                    materiaEcon.Mostrar();
                    Console.WriteLine($"Marcaste como aprobada la materia {materiaEcon.CodigoMateria}. Está usted seguro? S/N\n");
                    var keyEcon = Console.ReadKey(intercept: true);
                    if (keyEcon.Key == ConsoleKey.S)
                    {
                        Console.WriteLine($"{materiaEcon.NombreMateria} ha sido marcada como aprobada");
                        MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materiaEcon.CodigoMateria, materiaEcon.NombreMateria);
                    }

                    otraAprobada(eleccionCarrera, CodigoPersona);
                    break;
                
                case "2":
                    break;
            }

                Console.WriteLine("Seleccione la segunda materia en la cual quiere inscribirse");
                Console.WriteLine("Seleccione la tercera materia en la cual quiere inscribirse");
            
            Console.WriteLine("Seleccione la segunda materia en la cual quiere inscribirse");
            Console.WriteLine("Seleccione la tercera materia en la cual quiere inscribirse");
        }
    }
}
