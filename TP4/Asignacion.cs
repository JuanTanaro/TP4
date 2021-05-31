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
        public int CodigoMateria1 { get; set; }
        public string NombreMateria1 { get; set; }
        public int CodigoMateria2 { get; set; }
        public string NombreMateria2 { get; set; }
        public int CodigoMateria3 { get; set; }
        public string NombreMateria3 { get; set; }


        public Asignacion() { }

        public Asignacion(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            CodigoMateria1 = int.Parse(datos[1]);
            NombreMateria1 = (datos[2]);
        }
        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"{CodigoMateria1}" + "" + $"{NombreMateria1}");
            Console.WriteLine();
        }
    }
}
