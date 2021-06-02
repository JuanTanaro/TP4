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
        private static readonly Dictionary<int, Materias> entradas;
        const string nombreArchivo = "MateriasAprobadasAlumnos.txt";

        static MateriasAprobadasPorAlumno()
        {
            entradas = new Dictionary<int, Materias>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var materiasAprobadasAlumno = new Materias(linea);
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

        public static Materias Seleccionar(int CodigoPersona)
        {
            var modelo = Materias.CrearModeloBusquedaAlumno(CodigoPersona);
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
