using System;
using System.Collections.Generic;
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
            Console.WriteLine($"{NRegistro}" + "" + $"{NombreMateria1}");
            Console.WriteLine();
        }

        public static Asignacion Asignar()
        {
            var inscripcion = new Asignacion();

            Console.WriteLine("Inscripcion");

            inscripcion.NRegistro = IngresarNumero("Ingrese su registro");
            inscripcion.NombreMateria1 = Ingreso("Ingrese el nombre de la 1ra materia");
            inscripcion.NombreMateria2 = Ingreso("Ingrese el nombre de la 2da materia");
            inscripcion.NombreMateria3 = Ingreso("Ingrese el nombre de la 3ra materia");

            return inscripcion;
        }

        //Validaciones e ingresos

        private static int IngresarNumero(string titulo)
        {
            do
            {
                Console.WriteLine(titulo);

                var ingreso = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var codigoCuenta))
                {
                    Console.WriteLine("No ha ingresado un registro válido");
                    continue;
                }

                return codigoCuenta;

            } while (true);
        }

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
