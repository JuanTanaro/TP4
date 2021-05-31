using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Alumno
    {
        public int NRegistro { get; set; }
        public string NombreAlumno { get; set; }

        public Alumno() { }

        public Alumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            NombreAlumno = (datos[1]);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("Hola!" + $"Nombre: {NombreAlumno}");
            Console.WriteLine();
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
            if (!obligatorio)
            {
                titulo += " o presione [Enter] para continuar";
            }

            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var codigoCuenta))
                {
                    Console.WriteLine("No ha ingresado un numero de registro válido");
                    continue;
                }

                return codigoCuenta;

            } while (true);
        }
    }
}
