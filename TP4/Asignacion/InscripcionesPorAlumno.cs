using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class InscripcionesPorAlumno
    {
        public int NRegistro { get; set; }
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public InscripcionesPorAlumno() { }

        public InscripcionesPorAlumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            NombreMateria = (datos[2]);
        }

        public string ObtenerLineaDatosAlumno() => $"{NRegistro}-{CodigoMateria}-{NombreMateria}";

        public static List<InscripcionesPorAlumno> inscripcionesPorAlumno = new List<InscripcionesPorAlumno>();
        const string nombreArchivo = "InscripcionesPorAlumnos.txt";

        public static void EscribirAprobadasEnTXT()
        {
            if (File.Exists(nombreArchivo))
            {
                using (TextWriter tw = new StreamWriter(nombreArchivo))
                {
                    foreach (var materiaAprobada in inscripcionesPorAlumno)
                    {
                        tw.WriteLine("Numero de registro:" + materiaAprobada.NRegistro + " | Codigo de materia:" + materiaAprobada.CodigoMateria + " | Nombre de materia:" + materiaAprobada.NombreMateria);
                    }

                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el archivo TXT");
            }
        }


        public static void AgregarInscripcion(int numRegistro, int codMateria, string nomMateria)
        {
            inscripcionesPorAlumno.Add(new InscripcionesPorAlumno()
            {
                NRegistro = numRegistro,
                CodigoMateria = codMateria,
                NombreMateria = nomMateria,
            });
        }

        public static void MostrarInscripciones(int CodigoPersona)
        {
            var materiasInscriptas = inscripcionesPorAlumno.Where(inscripcionesGeneral => inscripcionesPorAlumno.All(inscripto => inscripto.NRegistro == inscripcionesGeneral.NRegistro));
            Console.WriteLine($"Materias en las que se encuentra inscripto:");   
            foreach (var val in materiasInscriptas)           
            {           
                Console.WriteLine($"Codigo de materia: " + val.CodigoMateria + $" | Nombre de materia: " + val.NombreMateria);           
            }           
        }

        public static void AgregarInscripcionALista(int numRegistro, int codMateria, string nomMateria)
        {
            inscripcionesPorAlumno.Add(new InscripcionesPorAlumno()
            {
                NRegistro = numRegistro,
                CodigoMateria = codMateria,
                NombreMateria = nomMateria,
            });
        }
    }
}
