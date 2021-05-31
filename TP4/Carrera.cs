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
        private static readonly Dictionary<int, Econo> entradas;
        const string nombreArchivo = "economia.txt";

        static Carrera()
        {
            entradas = new Dictionary<int, Econo>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new Econo(linea);
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
        }
    }
}
