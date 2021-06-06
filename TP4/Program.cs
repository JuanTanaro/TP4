using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TP4
{
    public class Program
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
                Console.WriteLine("0 - Salir");


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
                    case "4":
                        MostrarMaterias(eleccionCarrera, CodigoPersona);
                        break;
                    case "5":
                        MostrarMaterias(eleccionCarrera, CodigoPersona);
                        break;
                    case "6":
                        MostrarMaterias(eleccionCarrera, CodigoPersona);
                        break;
                    case "0":
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

            if (eleccionCarrera == "3")
            {
                Contador.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona);
            }

            if (eleccionCarrera == "4")
            {
                ActuarioAdministracion.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona);
            }

            if (eleccionCarrera == "5")
            {
                ActuarioEconomia.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona);
            }

            if (eleccionCarrera == "6")
            {
                Administracion.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona);
            }
        }

        private static void Aprobada(string eleccionCarrera, int CodigoPersona)
        {
            Console.WriteLine("\nSeleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");

            if (eleccionCarrera == "1")
            {
                var materia = Economia.Seleccionar(); //te devuelve el codigo de materia en .int
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

            if (eleccionCarrera == "3")
            {
                var materia = Contador.Seleccionar(); //te devuelve el codigo de materia en .int
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

            if (eleccionCarrera == "4")
            {
                var materia = ActuarioAdministracion.Seleccionar(); //te devuelve el codigo de materia en .int
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

            if (eleccionCarrera == "5")
            {
                var materia = ActuarioEconomia.Seleccionar(); //te devuelve el codigo de materia en .int
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

            if (eleccionCarrera == "6")
            {
                var materia = Administracion.Seleccionar(); //te devuelve el codigo de materia en .int
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
            }
        }
        
        private static void InscripcionMaterias(int CodigoPersona, string eleccionCarrera)
        {
            MateriasAprobadasPorAlumno.MostrarMateriasDisponibles(eleccionCarrera, CodigoPersona);
            int materiasDisponiblesAlumno = MateriasAprobadasPorAlumno.contarMateriasDisponibles(CodigoPersona);
            Console.WriteLine("Usted tiene " + materiasDisponiblesAlumno + " materias disponibles");
            Console.WriteLine(" ");
            Console.WriteLine("-------------");
            Console.WriteLine(" ");
            Console.WriteLine("INSCRIPCIONES");
            Console.WriteLine(" ");
            Console.WriteLine("-------------");

            switch (eleccionCarrera)
            {
                case "1":
                    for (int i = 1; i <= 3; i++)
                    {

                        //Acumulador para saber el numero de materia
                        int materia = +i;

                        var materiaEcon = Economia.SeleccionarAsignacion(materia); //te devuelve el codigo de materia en .int
                        if (materiaEcon == null)
                        {
                            InscripcionMaterias(CodigoPersona, eleccionCarrera);
                        }

                        materiaEcon.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaEcon.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaEcon.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaEcon.CodigoMateria, materiaEcon.NombreMateria);
                        }
                    }

                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;

                case "2":
                    for (int i = 1; i <= 3; i++)
                    {

                        //Acumulador para saber el numero de materia
                        int materia = +i;

                        var materiaSist = Sistemas.SeleccionarAsignacion(materia); //te devuelve el codigo de materia en .int
                        if (materiaSist == null)
                        {
                            InscripcionMaterias(CodigoPersona, eleccionCarrera);
                        }

                        materiaSist.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaSist.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaSist.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaSist.CodigoMateria, materiaSist.NombreMateria);
                        }
                    }

                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;

                case "3":
                    for (int i = 1; i <= 3; i++)
                    {

                        //Acumulador para saber el numero de materia
                        int materia = +i;

                        var materiaCont = Contador.SeleccionarAsignacion(materia); //te devuelve el codigo de materia en .int
                        if (materiaCont == null)
                        {
                            InscripcionMaterias(CodigoPersona, eleccionCarrera);
                        }

                        materiaCont.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaCont.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyCont = Console.ReadKey(intercept: true);
                        if (keyCont.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaCont.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaCont.CodigoMateria, materiaCont.NombreMateria);
                        }
                    }

                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;

                case "4":
                    for (int i = 1; i <= 3; i++)
                    {

                        //Acumulador para saber el numero de materia
                        int materia = +i;

                        var materiaActAdm = ActuarioAdministracion.SeleccionarAsignacion(materia); //te devuelve el codigo de materia en .int
                        if (materiaActAdm == null)
                        {
                            InscripcionMaterias(CodigoPersona, eleccionCarrera);
                        }

                        materiaActAdm.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaActAdm.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyActAdm = Console.ReadKey(intercept: true);
                        if (keyActAdm.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaActAdm.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaActAdm.CodigoMateria, materiaActAdm.NombreMateria);
                        }
                    }

                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;

                case "5":
                    for (int i = 1; i <= 3; i++)
                    {

                        //Acumulador para saber el numero de materia
                        int materia = +i;

                        var materiaActEcon = ActuarioEconomia.SeleccionarAsignacion(materia); //te devuelve el codigo de materia en .int
                        if (materiaActEcon == null)
                        {
                            InscripcionMaterias(CodigoPersona, eleccionCarrera);
                        }

                        materiaActEcon.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaActEcon.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyActEcon = Console.ReadKey(intercept: true);
                        if (keyActEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaActEcon.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaActEcon.CodigoMateria, materiaActEcon.NombreMateria);
                        }
                    }

                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;

                case "6":
                    for (int i = 1; i <= 3; i++)
                    {

                        //Acumulador para saber el numero de materia
                        int materia = +i;

                        var materiaAdm = Administracion.SeleccionarAsignacion(materia); //te devuelve el codigo de materia en .int
                        if (materiaAdm == null)
                        {
                            InscripcionMaterias(CodigoPersona, eleccionCarrera);
                        }

                        materiaAdm.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaAdm.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyAdm = Console.ReadKey(intercept: true);
                        if (keyAdm.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaAdm.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaAdm.CodigoMateria, materiaAdm.NombreMateria);
                        }
                    }

                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;
            }
        }
    }
}
