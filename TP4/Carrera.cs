using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    static class Carrera
    {
        private static readonly Dictionary<int, Materias> entradas;
        const string nombreArchivo = "Economia.txt";

        static Carrera()
        {
            entradas = new Dictionary<int, Materias>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new Materias(linea);
                        entradas.Add(carrera.CodigoMateria, carrera);
                    }
                }
            }
        }

        public static void MostrarDatos()
        {
            string Mensaje = "";
            foreach (var materias in entradas.Values)
            {
                Mensaje += $"Codigo Materia: {materias.CodigoMateria}" + " " + $"Nombre Materia: {materias.NombreMateria}\n";
            }
            if (Mensaje != "")
            {
                Console.WriteLine("Las materias existentes son: " + System.Environment.NewLine + Mensaje);
            }
            if (Mensaje == "")
            {
                Console.WriteLine("No hay materias");
            }

        }
    }
}
