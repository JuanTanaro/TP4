using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    static class Inscripcion
    {
        private static readonly Dictionary<int, Asignacion> entradas;
        const string nombreArchivo = "Inscripcion.txt";

        static Inscripcion()
        {
            entradas = new Dictionary<int, Asignacion>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var asignacion = new Asignacion(linea);
                        entradas.Add(asignacion.NRegistro, asignacion);
                    }
                }
            }
        }
    }
}
