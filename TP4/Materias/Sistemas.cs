using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    static class Sistemas
    {
        private static readonly Dictionary<int, Materias> entradas;
        const string nombreArchivo = "Sistemas.txt";

        static Sistemas()
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
                Mensaje += $"Codigo Materia: {materias.CodigoMateria}" + " - " + $"Nombre Materia: {materias.NombreMateria}\n";
            }
            if (Mensaje != "")
            {
                Console.WriteLine(System.Environment.NewLine + Mensaje);
            }
            if (Mensaje == "")
            {
                Console.WriteLine("No hay materias");
            }

        }

        public static Materias Seleccionar()
        {
            var modelo = Materias.CrearModeloBusqueda();
            foreach (var persona in entradas.Values)
            {
                if (persona.CoincideCon(modelo))
                {
                    return persona;
                }
            }

            Console.WriteLine("No se ha encontrado una materia que coincida");
            return null;
        }

        public static void Baja(Materias materias)
        {
            entradas.Remove(materias.CodigoMateria);
            Grabar();
        }

        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false))
            {
                foreach (var persona in entradas.Values)
                {
                    var linea = persona.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }
    }
}
