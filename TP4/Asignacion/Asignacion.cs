using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Asignacion
    {
        public static List<InscripcionesPorAlumno> inscripcionesAsignacion = new List<InscripcionesPorAlumno>();
        public static List<InscripcionesPorAlumno> inscriptosPorMateria = new List<InscripcionesPorAlumno>();
        public static List<InscripcionesPorAlumno> cortePorRanking = new List<InscripcionesPorAlumno>();
        public static List<InscripcionesPorAlumno> cortePorRegistro = new List<InscripcionesPorAlumno>();
        public static List<InscripcionesPorAlumno> asignaciones = new List<InscripcionesPorAlumno>();
        public static void LeerInscripciones()
        {
            string nombreArchivo = "InscripcionesPorAlumnos.txt";
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new InscripcionesPorAlumno(linea);
                        inscripcionesAsignacion.Add(new InscripcionesPorAlumno()
                        {
                            NRegistro = carrera.NRegistro,
                            CodigoMateria = carrera.CodigoMateria,
                            NombreMateria = carrera.NombreMateria,
                            RankingAlumno = carrera.RankingAlumno,
                        });
                    }
                }
            }
        }

        public static void SumatoriaCantidadInscriptos()
        {
            foreach (var val in Economia.economia)
            {
                int contadorMateria = 0;
                foreach (var val2 in inscripcionesAsignacion)
                {
                    if(val.CodigoMateria == val2.CodigoMateria)
                    {
                        contadorMateria++;
                    }
                }
                inscriptosPorMateria.Add(new InscripcionesPorAlumno()
                {
                    CodigoMateria = val.CodigoMateria,
                    NombreMateria = val.NombreMateria,
                    CantidadInscriptos = contadorMateria,
                });
            }
        }
        
        public static void CorteDeRanking()
        {
            foreach(var val in Economia.economia)
            {
                foreach(var val2 in Asignacion.inscriptosPorMateria)
                {
                    if (val.CodigoMateria == val2.CodigoMateria)
                    {
                        if (val2.CantidadInscriptos != 0)
                        {
                            if (val.CapacidadMateria < val2.CantidadInscriptos)
                            {
                                asignaciones.Clear();
                                int capacidadRanking = (int)(val.CapacidadMateria * 0.70);
                                int capacidadRegistro = (int)(val.CapacidadMateria * 0.30);
                                cortePorRanking = inscripcionesAsignacion.OrderByDescending(o => o.RankingAlumno).ToList();
                                cortePorRegistro = inscripcionesAsignacion.OrderByDescending(o => o.RankingAlumno).ToList();

                                for (int i = 0; i < capacidadRanking; i++)
                                {
                                    asignaciones.Add(cortePorRanking[i]);
                                }
                                cortePorRegistro = Asignacion.inscripcionesAsignacion.Where(inscri => asignaciones.All(asig => asig.NRegistro != inscri.NRegistro)).ToList();
                                cortePorRegistro = cortePorRegistro.OrderBy(o => o.NRegistro).ToList();
                                for (int i = 0; i < capacidadRegistro; i++)
                                {
                                    asignaciones.Add(cortePorRegistro[i]);
                                }
                            }

                            else
                            {
                                foreach (var val4 in inscripcionesAsignacion)
                                {
                                    asignaciones.Add(new InscripcionesPorAlumno()
                                    {
                                        NRegistro = val4.NRegistro,
                                        CodigoMateria = val4.CodigoMateria,
                                        NombreMateria = val4.NombreMateria,
                                    });
                                }

                            }
                        }
                        
                    }
                }

            }
        }

        public static void EscribirAsignacionEnTXT()
        {
            string nombreArchivoAsignaciones = "AsignacionesPorAlumnos.txt";
            if (File.Exists(nombreArchivoAsignaciones))
            {
                using (StreamWriter sw = File.AppendText(nombreArchivoAsignaciones))
                {
                    foreach( var val in asignaciones)
                    {
                        sw.WriteLine("Numero de registro:" + val.NRegistro + " | Codigo de materia:" + val.CodigoMateria + " | Nombre de materia:" + val.NombreMateria);
                    }

                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el archivo TXT. El archivo 'InscripcionesPorAlumnos.txt' debe estar en la carpeta Debug");
            }
        }


        //VALIDACION 2: Ranking?
    }
}
