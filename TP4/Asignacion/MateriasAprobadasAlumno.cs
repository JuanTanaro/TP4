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
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }


        public MateriasAprobadasAlumno() { }

        public MateriasAprobadasAlumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            NombreMateria = (datos[2]);
        }

        public string ObtenerLineaDatos() => $"{NRegistro}-{CodigoMateria}-{NombreMateria}";

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

        public static MateriasAprobadasAlumno Seleccionar(int CodigoPersona)
        {
            var modelo = CrearModeloBusqueda(CodigoPersona);
            foreach (var materias in entradas.Values)
            {
                if (materias.CoincideCon(modelo))
                {
                    return materias;
                }
            }

            Console.WriteLine("No se ha encontrado una materia que coincida");
            return null;
        }

        public static MateriasAprobadasAlumno CrearModeloBusqueda(int CodigoPersona)
        {
            var modelo = new MateriasAprobadasAlumno();
            modelo.NRegistro = CodigoPersona;
            return modelo;
        }

        public bool CoincideCon(MateriasAprobadasAlumno modelo)
        {
            if (modelo.NRegistro != 0 && modelo.NRegistro != NRegistro)
            {
                return false;
            }

            return true;

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
