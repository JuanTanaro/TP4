using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Econo
    {
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public Econo() { }

        public Econo(string linea)
        {
            var datos = linea.Split('-');
            CodigoMateria = int.Parse(datos[0]);
            NombreMateria = string.Format(datos[1]);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"Codigo de Materia: {CodigoMateria}" + $"Nombre de Materia: {NombreMateria}");
            Console.WriteLine();
        }

        public static Econo CrearModeloBusqueda()
        {
            var modelo = new Econo();
            modelo.CodigoMateria = IngresarNumeroAsiento(obligatorio: false);
            return modelo;
        }

        public bool CoincideCon(Econo modelo)
        {
            if (modelo.CodigoMateria != 0 && modelo.CodigoMateria != CodigoMateria)
            {
                return false;
            }
            return true;

        }

        //Validaciones e ingresos

        private static int IngresarNumeroAsiento(bool obligatorio = true)
        {
            var titulo = "Ingrese el numero de asiento";
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

                if (!int.TryParse(ingreso, out var numeroAsiento))
                {
                    Console.WriteLine("No ha ingresado un numero de asiento válido");
                    continue;
                }

                return numeroAsiento;

            } while (true);
        }
    }
}
