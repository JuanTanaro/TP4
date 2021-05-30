using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class CEconomia
    {
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public CEconomia() { }

        public CEconomia(string linea)
        {
            var datos = linea.Split('-');
            CodigoMateria = int.Parse(datos[0]);
            NombreMateria = string.Format(datos[1]);
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"Codigo de Materia {CodigoMateria}");
            Console.WriteLine($"Nombre de Materia {NombreMateria}");
            Console.WriteLine();
        }


    }
}
