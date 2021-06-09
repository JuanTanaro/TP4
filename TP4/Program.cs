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
            Console.WriteLine("¿Tiene una materia aprobada?");
            Console.WriteLine("1 - SI");
            Console.WriteLine("2 - NO");

            var respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "1":
                    SeleccionarAprobada(eleccionCarrera, CodigoPersona);
                    break;
                case "2":
                    MateriasAprobadasPorAlumno.EscribirAprobadasEnTXT();
                    AjustesInscripcionMaterias(CodigoPersona, eleccionCarrera);
                    break;
            }
        }

        private static void SeleccionarAprobada(string eleccionCarrera, int CodigoPersona)
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
                var key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }
                else
                {
                    Console.WriteLine($"{materia.NombreMateria} NO ha sido marcada como aprobada");

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
                var key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }
                else
                {
                    Console.WriteLine($"{materia.NombreMateria} NO ha sido marcada como aprobada");

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
                var key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }
                else
                {
                    Console.WriteLine($"{materia.NombreMateria} NO ha sido marcada como aprobada");

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
                var key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }
                else
                {
                    Console.WriteLine($"{materia.NombreMateria} NO ha sido marcada como aprobada");

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
                var key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }
                else
                {
                    Console.WriteLine($"{materia.NombreMateria} NO ha sido marcada como aprobada");

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
                var key = Console.ReadLine();
                if (key.ToUpper() == "S")
                {
                    Console.WriteLine($"{materia.NombreMateria} ha sido marcada como aprobada");
                    MateriasAprobadasPorAlumno.AgregarMateria(CodigoPersona, materia.CodigoMateria, materia.NombreMateria);
                }
                else
                {
                    Console.WriteLine($"{materia.NombreMateria} NO ha sido marcada como aprobada");

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
                    SeleccionarAprobada(eleccionCarrera, CodigoPersona);
                    break;
                case "2":
                    MateriasAprobadasPorAlumno.EscribirAprobadasEnTXT();
                    AjustesInscripcionMaterias(CodigoPersona, eleccionCarrera);
                    break;
            }
        }

        private static void AjustesInscripcionMaterias(int CodigoPersona, string eleccionCarrera)
        {
            Console.WriteLine(" ");
            Console.WriteLine("-------------");
            Console.WriteLine(" ");
            Console.WriteLine("INSCRIPCIONES");
            MateriasAprobadasPorAlumno.MostrarMateriasDisponibles(eleccionCarrera, CodigoPersona);
            Console.WriteLine(" ");
            int countMateriasAprobadasAlumno = MateriasAprobadasPorAlumno.contarMateriasAprobadas(CodigoPersona);
            int countMateriasDisponiblesAlumno = MateriasAprobadasPorAlumno.contarMateriasDisp(CodigoPersona);
            Console.WriteLine("Usted tiene " + countMateriasDisponiblesAlumno + " materias disponibles");
            Console.WriteLine(" ");
            Console.WriteLine("-------------");

            int CantidadMax;

            switch (eleccionCarrera)
            {
                case "1":
                    if ((Economia.CantidadMateriasEcon - countMateriasAprobadasAlumno) <= 4)
                    {
                        CantidadMax = 4;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    else
                    {
                        CantidadMax = 3;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    break;

                case "2":
                    if ((Sistemas.CantidadMateriasSist - countMateriasAprobadasAlumno) <= 4)
                    {
                        CantidadMax = 4;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    else
                    {
                        CantidadMax = 3;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    break;

                case "3":
                    if ((Contador.CantidadMateriasCont - countMateriasAprobadasAlumno) <= 4)
                    {
                        CantidadMax = 4;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    else
                    {
                        CantidadMax = 3;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    break;

                case "4":
                    if ((ActuarioAdministracion.CantidadMateriasActAdm - countMateriasAprobadasAlumno) <= 4)
                    {
                        CantidadMax = 4;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    else
                    {
                        CantidadMax = 3;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    break;

                case "5":
                    if ((ActuarioEconomia.CantidadMateriasActEcon - countMateriasAprobadasAlumno) <= 4)
                    {
                        CantidadMax = 4;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    else
                    {
                        CantidadMax = 3;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    break;

                case "6":
                    if ((Administracion.CantidadMateriasAdm - countMateriasAprobadasAlumno) <= 4)
                    {
                        CantidadMax = 4;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    else
                    {
                        CantidadMax = 3;
                        Inscripciones(CodigoPersona, eleccionCarrera, countMateriasAprobadasAlumno, CantidadMax);
                    }
                    break;
            }
            

        }

        private static void Inscripciones(int CodigoPersona, string eleccionCarrera, int materiasDisponiblesAlumno, int CantidadMax)
        {
            switch (eleccionCarrera)
            {
                case "1":
                    if (CantidadMax > 0)
                    {
                        var materiaEcon = Economia.SeleccionarAsignacion(CantidadMax);
                        if (materiaEcon == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, materiasDisponiblesAlumno, CantidadMax);
                        }

                        materiaEcon.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaEcon.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaEcon.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaEcon.CodigoMateria, materiaEcon.NombreMateria);
                        }

                        otraInscripcion(CodigoPersona, eleccionCarrera, materiasDisponiblesAlumno, CantidadMax);
                    }
                    else if(CantidadMax == 0)
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");
                        InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    }
                break;

            }    
        }

        private static void otraInscripcion(int CodigoPersona, string eleccionCarrera, int materiasDisponiblesAlumno, int CantidadMax)
        {
            Console.WriteLine("¿Quiere inscribirse a otra materia?");
            Console.WriteLine("1 - SI");
            Console.WriteLine("2 - NO");

            var respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "1":
                    CantidadMax = CantidadMax - 1;
                    Inscripciones(CodigoPersona, eleccionCarrera, materiasDisponiblesAlumno, CantidadMax);
                    break;
                case "2":
                    CantidadMax = 0;
                    Inscripciones(CodigoPersona, eleccionCarrera, materiasDisponiblesAlumno, CantidadMax);
                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;
            }
        }
    }
}
