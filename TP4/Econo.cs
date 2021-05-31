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
    }
}
