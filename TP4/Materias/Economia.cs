using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Economia
    {

        public static Dictionary<int, MateriasBase> economia;
        public static List<MateriasBase> economia2 = new List<MateriasBase>();


        const string nombreArchivo = "Economia.txt";

        static Economia()
        {
            economia = new Dictionary<int, MateriasBase>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new MateriasBase(linea);
                        economia.Add(carrera.CodigoMateria, carrera);
                        economia2.Add(new MateriasBase()
                        {
                            CodigoMateria = carrera.CodigoMateria,
                            NombreMateria = carrera.NombreMateria,
                        });
                    }
                }
            }       
        }


        public static void MostrarTXT()
        {
            string Mensaje = "";
            foreach (var materias in economia.Values)
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

        public static MateriasBase Seleccionar()
        {
            var modelo = MateriasBase.CrearModeloBusqueda();
            foreach (var persona in economia.Values)
            {
                if (persona.CoincideCon(modelo))
                {
                    return persona;
                }
            }

            Console.WriteLine("No se ha encontrado una materia que coincida");
            return null;
        }

        public static void Baja(MateriasBase materias)
        {
            economia.Remove(materias.CodigoMateria);
            //Grabar();
        }
        /*
        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false))
            {
                foreach (var materias in economia.Values)
                {
                    var linea = materias.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }
        */
    }
}
