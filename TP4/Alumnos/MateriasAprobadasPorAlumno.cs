using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class MateriasAprobadasPorAlumno
    {
        public int NRegistro { get; set; }
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public MateriasAprobadasPorAlumno() { }

        public MateriasAprobadasPorAlumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            NombreMateria = (datos[2]);
        }

        public string ObtenerLineaDatosAlumno() => $"{NRegistro}-{CodigoMateria}-{NombreMateria}";

        public static List<MateriasAprobadasPorAlumno> JuampiAprobadas = new List<MateriasAprobadasPorAlumno>();
        const string nombreArchivo = "MateriasAprobadasAlumnos.txt";

        public static void EscribirAprobadasEnTXT()
        {
            if (File.Exists(nombreArchivo))
            {
                using (TextWriter tw = new StreamWriter(nombreArchivo))
                {
                    foreach (var materiaAprobada in JuampiAprobadas)
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
        public static void AgregarMateria(int numRegistro, int codMateria, string nomMateria)
        {
            JuampiAprobadas.Add(new MateriasAprobadasPorAlumno()
            {
                NRegistro = numRegistro,
                CodigoMateria = codMateria,
                NombreMateria = nomMateria,
            });
        }


        public static void MostrarMateriasDisponibles(string eleccionCarrera)
        {
            switch (eleccionCarrera)
            {
                case "1":
                    var materiasDisponiblesEcon = Economia.economia.Where(econ => MateriasAprobadasPorAlumno.JuampiAprobadas.All(aprob => aprob.CodigoMateria != econ.CodigoMateria));
                    Console.WriteLine($"Materias disponibles para inscrpcion:");
                    foreach (var val in materiasDisponiblesEcon)
                    {
                        Console.WriteLine($"Codigo de materia: " + val.CodigoMateria + $" | Nombre de materia: " + val.NombreMateria);
                    }
                    break;

                case "2":
                    var materiasDisponiblesSist = Sistemas.sistemas.Where(sist => MateriasAprobadasPorAlumno.JuampiAprobadas.All(aprob => aprob.CodigoMateria != sist.CodigoMateria));
                    Console.WriteLine($"Materias disponibles para inscrpcion:");
                    foreach (var val in materiasDisponiblesSist)
                    {
                        Console.WriteLine($"Codigo de materia: " + val.CodigoMateria + $" | Nombre de materia: " + val.NombreMateria);
                    }
                    break;

            }
        }




        public static MateriasAprobadasPorAlumno CrearModeloBusquedaAlumno(int CodigoPersona)
        {
            var modelo = new MateriasAprobadasPorAlumno();
            modelo.CodigoMateria = CodigoPersona;
            return modelo;
        }

        public bool CoincideConAlumno(MateriasAprobadasPorAlumno modelo)
        {
            if (modelo.NRegistro != 0 && modelo.NRegistro != NRegistro)
            {
                return false;
            }

            return true;

        }
    }
}
