using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class MateriasAprobadasAlumno
    {
        public int NRegistro { get; set; }
        public string NombreMateria { get; set; }


        public MateriasAprobadasAlumno() { }

        public MateriasAprobadasAlumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            NombreMateria = (datos[1]);
        }

        public string ObtenerLineaDatos() => $"{NRegistro}-{NombreMateria}";

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"{NRegistro}" + "" + $"{NombreMateria}");
            Console.WriteLine();
        }


        private static readonly Dictionary<int, MateriasAprobadasAlumno> entradas;
        const string nombreArchivo = "MateriasAprobadasAlumnos.txt";

        static MateriasAprobadasAlumno()
        {
            entradas = new Dictionary<int, MateriasAprobadasAlumno>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var materiasAprobadasAlumno = new MateriasAprobadasAlumno(linea);
                        entradas.Add(materiasAprobadasAlumno.NRegistro, materiasAprobadasAlumno);
                    }
                }
            }
        }

        public static void Agregar(int CodigoPersona, Materias materiasAprobadasAlumno)
        {
            entradas.Add(CodigoPersona, materiasAprobadasAlumno);
            Grabar();
        }

        public static void MostrarDatos()
        {
            string Mensaje = "";
            foreach (var materias in entradas.Values)
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

        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false))
            {
                foreach (var materiaAprobada in entradas.Values)
                {
                    var linea = materiaAprobada.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }
    }
}
