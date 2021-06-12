﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TP4
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("-------------");
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("-------------");
                Console.WriteLine("¿Que tipo de usuario es usted?");
                Console.WriteLine("1 - Administrador");
                Console.WriteLine("2 - Estudiante");
                Console.WriteLine("0 - Salir del sitio");
                var respuesta = Console.ReadLine();
                

                switch (respuesta)
                {
                    case "1":
                        Inicio(respuesta);
                        break;
                    case "2":
                        Inicio(respuesta);
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú\n");
                        break;
                }

            } while (!salir);

        }

        private static void Inicio(string respuesta)
        {
            if (respuesta == "1")
            {
                var persona = Administrador.Seleccionar();
                if (persona == null)
                {
                    Inicio(respuesta);
                }
                persona?.Mostrar();

                int ID = persona.ID;

                var Verificar = Administrador.VerificarPassword(ID);
                if (Verificar == null)
                {
                    Administrador.VerificarPassword(ID);
                }


                MenuAdmin();
            }
            else if (respuesta == "2")
            {
                var persona = Alumno.Seleccionar();
                if (persona == null)
                {
                    Inicio(respuesta);
                }
                persona?.Mostrar();


                int CodigoPersona = persona.NRegistro;
                double rankingAlumno = (int)(persona.Ranking);

                var Verificar = Alumno.VerificarPassword(CodigoPersona);
                if (Verificar == null)
                {
                    Alumno.VerificarPassword(CodigoPersona);
                }


                MenuEstudiante(CodigoPersona, rankingAlumno);
            }
        }

        private static void MenuAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine("MENU ADMINISTRADOR");
            Console.WriteLine("-------------");
            Console.WriteLine("1 - Asignar materias a los alumnos");
            Console.WriteLine("2 - Ver reclamos");
            var respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "1":
                    Asignacion.LeerMateriasFCE();
                    Asignacion.LeerInscripciones();
                    Asignacion.SumatoriaCantidadInscriptos();

                    foreach (var val in Asignacion.inscriptosPorMateria)
                    {
                        Console.WriteLine("Nombre de materia:" + val.NombreMateria + "| Cantidad de inscriptos:" + val.CantidadInscriptos);
                    }
                    Console.ReadKey();

                    Asignacion.CorteDeRanking();
                    Asignacion.EscribirAsignacionEnTXT();

                    MenuAdmin();
                    break;
                case "2":
                    //Reclamos();
                    break;
                default:
                    Console.WriteLine("No ha ingresado una opción del menú\n");
                    break;
            }

        }

        private static void MenuEstudiante(int CodigoPersona, double rankingAlumno)
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("-------------");
                Console.WriteLine("MENU ESTUDIANTE");
                Console.WriteLine("-------------");
                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("1 - Inscribirse a materias");
                Console.WriteLine("2 - Ver inscripciones");
                Console.WriteLine("3 - Realizar reclamo");
                Console.WriteLine("0 - Salir del sitio");

                var eleccion = Console.ReadLine();

                switch (eleccion)
                {
                    case "1":
                        SeleccionarCarrera(CodigoPersona, rankingAlumno);
                        break;
                    case "2":
                        Asignacion.MostrarAsignaciones(CodigoPersona);
                        MenuEstudiante(CodigoPersona, rankingAlumno);
                        break;
                    case "3":
                        //Reclamo();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú\n");
                        MenuEstudiante(CodigoPersona, rankingAlumno);
                        break;
                }

            } while (!salir);
        }

        private static void SeleccionarCarrera(int CodigoPersona, double rankingAlumno)
        {
            bool salir = false;
            do
            {
                // Seleccionamos la carrera
                Console.WriteLine("\nSELECCIONAR CARRERA");
                Console.WriteLine("Para luego anotarse a las materias");
                Console.WriteLine("1 - Economia");
                Console.WriteLine("2 - Sistemas");
                Console.WriteLine("3 - Contador Publico");
                Console.WriteLine("4 - Actuario en administracion");
                Console.WriteLine("5 - Actuario en economia");
                Console.WriteLine("6 - Administracion de empresas");
                Console.WriteLine("0 - Salir del sitio");


                var eleccionCarrera = Console.ReadLine();

                switch (eleccionCarrera)
                {
                    case "1":
                        MostrarMaterias(eleccionCarrera, CodigoPersona, rankingAlumno);
                        break;
                    case "2":
                        MostrarMaterias(eleccionCarrera, CodigoPersona, rankingAlumno);
                        break;
                    case "3":
                        MostrarMaterias(eleccionCarrera, CodigoPersona, rankingAlumno);
                        break;
                    case "4":
                        MostrarMaterias(eleccionCarrera, CodigoPersona, rankingAlumno);
                        break;
                    case "5":
                        MostrarMaterias(eleccionCarrera, CodigoPersona, rankingAlumno);
                        break;
                    case "6":
                        MostrarMaterias(eleccionCarrera, CodigoPersona, rankingAlumno);
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú\n");
                        SeleccionarCarrera(CodigoPersona, rankingAlumno);
                        break;
                }

            } while (!salir) ;
        }

        private static void MostrarMaterias(string eleccionCarrera, int CodigoPersona, double rankingAlumno)
        {
            if (eleccionCarrera == "1")
            {
                Economia.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "2")
            {
                Sistemas.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "3")
            {
                Contador.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "4")
            {
                ActuarioAdministracion.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "5")
            {
                ActuarioEconomia.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "6")
            {
                Administracion.MostrarTXT();
                Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }
        }

        private static void Aprobada(string eleccionCarrera, int CodigoPersona, double rankingAlumno)
        {
            Console.WriteLine("¿Tiene una materia aprobada?");
            Console.WriteLine("1 - SI");
            Console.WriteLine("2 - NO");

            var respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "1":
                    SeleccionarAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
                    break;
                case "2":
                    MateriasAprobadasPorAlumno.EscribirAprobadasEnTXT();
                    AjustesInscripcionMaterias(CodigoPersona, eleccionCarrera, rankingAlumno);
                    break;
                default:
                    Console.WriteLine("No ha ingresado una opción del menú\n");
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
                    break;
            }
        }

        private static void SeleccionarAprobada(string eleccionCarrera, int CodigoPersona, double rankingAlumno)
        {
            Console.WriteLine("\nSeleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");

            if (eleccionCarrera == "1")
            {
                var materia = Economia.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
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

                otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);

            }

            if (eleccionCarrera == "2")
            {
                var materia = Sistemas.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
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

                otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "3")
            {
                var materia = Contador.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
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

                otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "4")
            {
                var materia = ActuarioAdministracion.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
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

                otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "5")
            {
                var materia = ActuarioEconomia.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
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

                otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }

            if (eleccionCarrera == "6")
            {
                var materia = Administracion.Seleccionar(); //te devuelve el codigo de materia en .int
                if (materia == null)
                {
                    Aprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
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

                otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
            }
        }

        private static void otraAprobada(string eleccionCarrera, int CodigoPersona, double rankingAlumno)
        {
            Console.WriteLine("¿Tiene otra materia aprobada?");
            Console.WriteLine("1 - SI");
            Console.WriteLine("2 - NO");

            var respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "1":
                    SeleccionarAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
                    break;
                case "2":
                    MateriasAprobadasPorAlumno.EscribirAprobadasEnTXT();
                    AjustesInscripcionMaterias(CodigoPersona, eleccionCarrera, rankingAlumno);
                    break;
                default:
                    Console.WriteLine("No ha ingresado una opción del menú\n");
                    otraAprobada(eleccionCarrera, CodigoPersona, rankingAlumno);
                    break;
            }
        }

        private static void AjustesInscripcionMaterias(int CodigoPersona, string eleccionCarrera, double rankingAlumno)
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
            bool entrarLoop = true;
            int cantidadMax=0;
            do
            {
                Console.WriteLine("Esta en las ultimas 4 materias?");
                Console.WriteLine("1 - SI");
                Console.WriteLine("2 - NO");
                string respuesta = Console.ReadLine();
                if (respuesta == "1")
                {
                    cantidadMax = 4;
                    entrarLoop = false;
                }
                else if (respuesta == "2")
                {
                    cantidadMax = 3;
                    entrarLoop = false;
                }
                else
                {
                    Console.WriteLine("No es una de las opciones. Escriba 1 o 2");
                }
            }
            while ( entrarLoop == true);

            Inscripciones(CodigoPersona, eleccionCarrera, cantidadMax, rankingAlumno);
            
        }

        private static void Inscripciones(int CodigoPersona, string eleccionCarrera, int CantidadMax, double rankingAlumno)
        {
            switch (eleccionCarrera)
            {
                case "1":
                    if (CantidadMax > 0)
                    {
                        var materiaEcon = Economia.SeleccionarAsignacion(CantidadMax);
                        if (materiaEcon == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                        }

                        materiaEcon.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaEcon.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaEcon.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaEcon.CodigoMateria, materiaEcon.NombreMateria, rankingAlumno);
                        }

                        InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);

                        otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    }
                    else if(CantidadMax == -1 )
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");

                    }
                    break;
                case "2":
                    if (CantidadMax > 0)
                    {
                        var materiaSistemas = Sistemas.SeleccionarAsignacion(CantidadMax);
                        if (materiaSistemas == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                        }

                        materiaSistemas.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaSistemas.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaSistemas.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaSistemas.CodigoMateria, materiaSistemas.NombreMateria, rankingAlumno);
                        }

                        otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    }
                    else if (CantidadMax == 0)
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");
                        

                    }
                    break;
                case "3":
                    if (CantidadMax > 0)
                    {
                        var materiaContador = Contador.SeleccionarAsignacion(CantidadMax);
                        if (materiaContador == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                        }

                        materiaContador.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaContador.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaContador.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaContador.CodigoMateria, materiaContador.NombreMateria, rankingAlumno);
                        }

                        otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    }
                    else if (CantidadMax == 0)
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");
                        

                    }
                    break;
                case "4":
                    if (CantidadMax > 0)
                    {
                        var materiaActAdmin = ActuarioAdministracion.SeleccionarAsignacion(CantidadMax);
                        if (materiaActAdmin == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                        }

                        materiaActAdmin.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaActAdmin.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaActAdmin.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaActAdmin.CodigoMateria, materiaActAdmin.NombreMateria, rankingAlumno);
                        }

                        otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    }
                    else if (CantidadMax == 0)
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");
                        

                    }
                    break;
                case "5":
                    if (CantidadMax > 0)
                    {
                        var materiaActEcono = ActuarioEconomia.SeleccionarAsignacion(CantidadMax);
                        if (materiaActEcono == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                        }

                        materiaActEcono.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaActEcono.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaActEcono.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaActEcono.CodigoMateria, materiaActEcono.NombreMateria, rankingAlumno);
                        }

                        otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    }
                    else if (CantidadMax == 0)
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");
                        

                    }
                    break;
                case "6":
                    if (CantidadMax > 0)
                    {
                        var materiaAdmEmpresas = Administracion.SeleccionarAsignacion(CantidadMax);
                        if (materiaAdmEmpresas == null)
                        {
                            Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                        }

                        materiaAdmEmpresas.Mostrar();
                        Console.WriteLine($"Te has inscripto en {materiaAdmEmpresas.CodigoMateria}. Está usted seguro? S/N\n");
                        var keyEcon = Console.ReadKey(intercept: true);
                        if (keyEcon.Key == ConsoleKey.S)
                        {
                            Console.WriteLine($"Has sido inscripto en {materiaAdmEmpresas.NombreMateria}");
                            InscripcionesPorAlumno.AgregarInscripcion(CodigoPersona, materiaAdmEmpresas.CodigoMateria, materiaAdmEmpresas.NombreMateria, rankingAlumno);
                        }

                        otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    }
                    else if (CantidadMax == 0)
                    {
                        Console.WriteLine("¡No se puede inscribir a más materias, accedera a sus inscripciones hasta el momento!\n");
                        

                    }
                    break;
            }

            
        }

        private static void otraInscripcion(int CodigoPersona, string eleccionCarrera, int CantidadMax, double rankingAlumno)
        {
            Console.WriteLine("\n¿Quiere inscribirse a otra materia?");
            Console.WriteLine("1 - SI");
            Console.WriteLine("2 - NO");

            var respuesta = Console.ReadLine();

            switch (respuesta)
            {
                case "1":
                    CantidadMax = CantidadMax - 1;
                    Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    break;
                case "2":
                    CantidadMax = -1;
                    Inscripciones(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    InscripcionesPorAlumno.MostrarInscripciones(CodigoPersona);
                    break;
                default:
                    Console.WriteLine("No ha ingresado una opción del menú\n");
                    otraInscripcion(CodigoPersona, eleccionCarrera, CantidadMax, rankingAlumno);
                    break;
            }
        }
    }
}
