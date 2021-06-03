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
                Console.WriteLine("No encontre el archivo TXT");
            }
        }


        public void AgregarMateria(int numRegistro, int codMateria, string nomMateria)
        {
            JuampiAprobadas.Add(new MateriasAprobadasPorAlumno()
            {
                NRegistro = numRegistro,
                CodigoMateria = codMateria,
                NombreMateria = nomMateria,
            });
        }

        public static void MostrarDatos(int CodigoPersona)
        {
            string Mensaje = "";

            foreach (var persona in JuampiAprobadas)
            {
                if (CodigoPersona == persona.NRegistro)
                {
                    foreach (var materias in JuampiAprobadas)
                    {
                        Mensaje += "Materia disponible: \n" + " - " + $"{materias.NombreMateria}\n";
                    }
                    if (Mensaje != "")
                    {
                        Console.WriteLine(System.Environment.NewLine + Mensaje);
                    }
                    if (Mensaje == "")
                    {
                        Console.WriteLine("No tiene materias disponibles");
                    }
                }
            }
        }
    }
}
