using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Asignacion
    {
        public int NRegistro { get; set; }
        public string NombreMateria1 { get; set; }
        public string NombreMateria2 { get; set; }
        public string NombreMateria3 { get; set; }


        public Asignacion() { }

        public Asignacion(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            NombreMateria1 = (datos[1]);
            NombreMateria1 = (datos[2]);
            NombreMateria1 = (datos[3]);
        }

        public string ObtenerLineaDatos() => $"{NRegistro}-{NombreMateria1}-{NombreMateria2}-{NombreMateria3}";

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"{NRegistro}" + "" + $"{NombreMateria1}" + "" + $"{NombreMateria2}" + "" + $"{NombreMateria3}");
            Console.WriteLine();
        }

        private static readonly Dictionary<int, Asignacion> entradas;
        const string nombreArchivo = "Asignacion.txt";

        static Asignacion()
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

        public static void Agregar(Asignacion asignacion)
        {
            entradas.Add(asignacion.NRegistro, asignacion);
            Grabar();
        }

        public static void MostrarDatos()
        {
            string Mensaje = "";
            foreach (var materias in entradas.Values)
            {
                Mensaje += "Usted a sido asignado a: \n" + " - " + $"{materias.NombreMateria1}\n" + " - " + $"{materias.NombreMateria2}\n" + " - " + $"{ materias.NombreMateria3}\n";
            }
            if (Mensaje != "")
            {
                Console.WriteLine(System.Environment.NewLine + Mensaje);
            }
            if (Mensaje == "")
            {
                Console.WriteLine("No ha sido asignado");
            }

        }

        public static void Grabar()
        {
            using (var writer = new StreamWriter(nombreArchivo, append: false))
            {
                foreach (var asignacion in entradas.Values)
                {
                    var linea = asignacion.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }

        public static Asignacion Asignar(int CodigoPersona)
        {
            var inscripcion = new Asignacion();

            Console.WriteLine("Inscripcion");

            inscripcion.NRegistro = CodigoPersona;
            inscripcion.NombreMateria1 = Ingreso("Ingrese el nombre de la primera materia a anotarse.");
            inscripcion.NombreMateria2 = Ingreso("Ingrese el nombre de la segunda materia a anotarse.");
            inscripcion.NombreMateria3 = Ingreso("Ingrese el nombre de la tercera materia a anotarse.");

            return inscripcion;
        }



        //Validaciones e ingresos
        private static string Ingreso(string titulo, bool permiteNumeros = false)
        {
            string ingreso;
            do
            {
                Console.WriteLine(titulo);

                ingreso = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un valor");
                    continue;
                }

                if (!permiteNumeros && ingreso.Any(c => Char.IsDigit(c)))
                {
                    Console.WriteLine("El valor ingresado no debe contener números");
                    continue;
                }

                break;

            } while (true);

            return ingreso;
        }

    }
}
