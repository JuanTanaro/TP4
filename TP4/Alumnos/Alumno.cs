using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Alumno
    {
        public int NRegistro { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public string CarreraAlumno { get; set; }
        public int MateriasAprobadas { get; set; }
        public int Ranking { get; set; }
        public int Promedio { get; set; }
        

        public Alumno() { }

        public Alumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            NombreAlumno = (datos[1]);
            ApellidoAlumno = (datos[2]);
            CarreraAlumno = (datos[3]);
            MateriasAprobadas = int.Parse(datos[4]);
            Ranking = int.Parse(datos[5]);
            Promedio = int.Parse(datos[6]);
        }
        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("Hola!" + $"{NombreAlumno} {ApellidoAlumno}");
            Console.WriteLine();
        }

        private static readonly Dictionary<int, Alumno> entradas;
        const string nombreArchivo = "Alumno.txt";

        static Alumno()
        {
            entradas = new Dictionary<int, Alumno>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var alumno = new Alumno(linea);
                        entradas.Add(alumno.NRegistro, alumno);
                    }
                }
            }
        }

        public static Alumno Seleccionar()
        {
            var modelo = CrearModeloBusqueda();
            foreach (var persona in entradas.Values)
            {
                if (persona.CoincideCon(modelo))
                {
                    return persona;
                }
            }

            Console.WriteLine("No se ha encontrado un alumno que coincida");
            return null;
        }

        public static Alumno CrearModeloBusqueda()
        {
            var modelo = new Alumno();
            modelo.NRegistro = IngresarRegistro(obligatorio: false);
            return modelo;
        }

        public bool CoincideCon(Alumno modelo)
        {
            if (modelo.NRegistro != 0 && modelo.NRegistro != NRegistro)
            {
                return false;
            }
            return true;

        }

        //Validaciones e ingresos

        private static int IngresarRegistro(bool obligatorio = true)
        {
            var titulo = "¿Cual es su numero de registro?";

            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var numeroRegistro))
                {
                    Console.WriteLine("No ha ingresado un numero de registro válido");
                    continue;
                }

                return numeroRegistro;

            } while (true);
        }
    }
}
