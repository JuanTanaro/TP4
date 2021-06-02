using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Materias
    {
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public Materias() { }

        public Materias(string linea)
        {
            var datos = linea.Split('-');
            CodigoMateria = int.Parse(datos[0]);
            NombreMateria = (datos[1]);
        }

        public string ObtenerLineaDatos() => $"{CodigoMateria}-{NombreMateria}";
        
        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"Codigo de Materia: {CodigoMateria}" + " " + $"Nombre de Materia: {NombreMateria}");
            Console.WriteLine();
        }

        public static Materias CrearModeloBusqueda()
        {
            var modelo = new Materias();
            modelo.CodigoMateria = IngresarCodigoMateria();
            return modelo;
        }

        public bool CoincideCon(Materias modelo)
        {
            if (modelo.CodigoMateria != 0 && modelo.CodigoMateria != CodigoMateria)
            {
                return false;
            }

            return true;

        }


        //Validaciones e ingresos

        private static int IngresarCodigoMateria()
        {
            var titulo = "Ingrese el codigo de materia";

            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("No ha ingresado un codigo de materia válido");
                    continue;
                }

                if (!int.TryParse(ingreso, out var codigomateria))
                {
                    Console.WriteLine("No ha ingresado un codigo de materia válido");
                    continue;
                }

                return codigomateria;

            } while (true);
        }


    }
}
