using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    static class Economia
    {
        private static readonly Dictionary<int, Materias> economia;
        const string nombreArchivo = "Economia.txt";
        public static Dictionary<int, String> ListaEconomia = new Dictionary<int, string>();

        static Economia()
        {
            economia = new Dictionary<int, Materias>();

            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new Materias(linea);
                        economia.Add(carrera.CodigoMateria, carrera);
                    }
                }
            }

            ListaEconomia.Add(247, "Teoría Contable");
            ListaEconomia.Add(248, "Estadistica I");
            ListaEconomia.Add(249, "Historia Economica y Social Argentina");
            ListaEconomia.Add(261, "Teoria Politica y Derecho Publico");
            ListaEconomia.Add(262, "Macroeconomia I");
            ListaEconomia.Add(284, "Analisis Matematico II");
            ListaEconomia.Add(283, "Macroeconomia II");
            ListaEconomia.Add(285, "Estadistica II");
            ListaEconomia.Add(286, "Microeconomía II");
            ListaEconomia.Add(287, "Geografía Económica");
            ListaEconomia.Add(288, "Matemática para Economistas");
            ListaEconomia.Add(289, "Epistemología de la Economía");
            ListaEconomia.Add(290, "Microeconomía I(para Economistas)");
            ListaEconomia.Add(551, "Econometría");
            ListaEconomia.Add(552, "Dinero, Crédito y Bancos");
            ListaEconomia.Add(553, "Historia del Pensamiento Económico");
            ListaEconomia.Add(554, "Crecimiento Económico");
            ListaEconomia.Add(555, "Organización Industrial");
            ListaEconomia.Add(556, "Finanzas Públicas");
            ListaEconomia.Add(557, "Estructura Social Argentina");
            ListaEconomia.Add(558, "Economía Internacional");
            ListaEconomia.Add(559, "Desarrollo Económico");
            ListaEconomia.Add(560, "Estructura Económica Argentina");
            ListaEconomia.Add(561, "Cuentas Nacionales");
            ListaEconomia.Add(562, "Seminario de Integración y Aplicación");           
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

        public static Materias Seleccionar()
        {
            var modelo = Materias.CrearModeloBusqueda();
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

        public static void Baja(Materias materias)
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
