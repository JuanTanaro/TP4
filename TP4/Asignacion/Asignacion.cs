using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Asignacion
{
    public class Asignacion
    {
        public static List<InscripcionesPorAlumno> inscripcionesAsignacion = new List<InscripcionesPorAlumno>();
        public static List<InscripcionesPorAlumno> inscriptosPorMateria = new List<InscripcionesPorAlumno>();
        public static List<InscripcionesPorAlumno> cortePorRanking = new List<InscripcionesPorAlumno>();
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
                        });
                    }
                }
            }
        }


        //VALIDACION 1: Cantidad de inscriptos al curso
        public static void SumatoriaCantidadInscriptos()
        {
            int contadorMateria = 0;
            foreach (var val in Economia.economia)
            {
                contadorMateria = Asignacion.inscripcionesAsignacion.Where(x => x.Equals(val.CodigoMateria)).Count();
                inscriptosPorMateria.Add(new InscripcionesPorAlumno()
                {
                    CantidadInscriptos = contadorMateria,
                    CodigoMateria = val.CodigoMateria,
                    NombreMateria = val.NombreMateria,
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
                        if(val.CapacidadMateria < val2.CantidadInscriptos)
                        {
                            int capacidadRanking = (int)(val.CapacidadMateria * 0.70);
                            int capacidadRegistro = (int)(val.CapacidadMateria * 0.30);
                            cortePorRanking = inscripcionesAsignacion.OrderByDescending(o => o.).ToList();
                            foreach (var val3 in cortePorRanking.Take(capacidadRanking))
                            {
                                asignaciones.Add(new InscripcionesPorAlumno()
                                {
                                    NRegistro = val3.NRegistro,
                                    CodigoMateria = val3.CodigoMateria,
                                    NombreMateria = val3.NombreMateria,
                                });
                            }

                            cortePorRanking = inscripcionesAsignacion.OrderBy(o => o.NRegistro).ToList();
                            foreach(var val3 in cortePorRanking.Take(capacidadRegistro))
                            {
                                asignaciones.Add(new InscripcionesPorAlumno()
                                {
                                    NRegistro = val3.NRegistro,
                                    CodigoMateria = val3.CodigoMateria,
                                    NombreMateria = val3.NombreMateria,
                                }); 
                            }
                        }
                        else
                        {
                            foreach(var val4 in inscripcionesAsignacion)
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
        

        //VALIDACION 2: Ranking?
    }
}
