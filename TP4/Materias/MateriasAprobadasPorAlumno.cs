using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class MateriasAprobadasPorAlumno
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


        private static readonly Dictionary<int, MateriasAprobadasPorAlumno> entradas;
        const string nombreArchivo = "MateriasAprobadasAlumnos.txt";

        static MateriasAprobadasPorAlumno()
        {
            entradas = new Dictionary<int, MateriasAprobadasPorAlumno>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var materiasAprobadasAlumno = new MateriasAprobadasPorAlumno(linea);
                        entradas.Add(materiasAprobadasAlumno.NRegistro, materiasAprobadasAlumno);
                    }
                }
            }
        }

        public static void Agregar(int CodigoPersona, MateriasAprobadasPorAlumno materiasAprobadasAlumno)
        {
            entradas.Add(CodigoPersona, materiasAprobadasAlumno);
            Grabar();
        }

        public static void MostrarDatos(int CodigoPersona)
        {
            string Mensaje = "";

            foreach (var persona in entradas.Values)
            {
                if (CodigoPersona == persona.NRegistro)
                {
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
            }
        }

        public static MateriasAprobadasPorAlumno Seleccionar(int CodigoPersona)
        {
            var modelo = CrearModeloBusquedaAlumno(CodigoPersona);
            foreach (var materias in entradas.Values)
            {
                if (materias.CoincideConAlumno(modelo))
                {
                    return materias;
                }
            }

            Console.WriteLine("No se ha encontrado una materia que coincida");
            return null;
        }


        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false))
            {
                foreach (var materiaAprobada in entradas.Values)
                {
                    var linea = materiaAprobada.ObtenerLineaDatosAlumno();
                    writer.WriteLine(linea);
                }
            }
        }

    }
}
