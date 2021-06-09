using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Sistemas
    {
        public static List<MateriasBase> sistemas = new List<MateriasBase>();
        public static int CantidadMateriasSist = 28;
        const string nombreArchivo = "Sistemas.txt";

        static Sistemas()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new MateriasBase(linea);
                        sistemas.Add(new MateriasBase()
                        {
                            CodigoMateria = carrera.CodigoMateria,
                            NombreMateria = carrera.NombreMateria,
                            ProfesorMateria = carrera.ProfesorMateria,
                            HorarioMateria = carrera.HorarioMateria,
                            CapacidadMateria = carrera.CapacidadMateria,
                            CorteDeRankingMateria = carrera.CorteDeRankingMateria,
                            Correlativa1 = carrera.Correlativa1,
                            Correlativa2 = carrera.Correlativa2,
                            Correlativa3 = carrera.Correlativa3,
                            Correlativa4 = carrera.Correlativa4,
                        });
                    }
                }
            }       
        }

        
        public static void MostrarTXT()
        {
            string Mensaje = "";
            foreach (var materias in sistemas)
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

        public static MateriasBase Seleccionar()
        {
            var modelo = MateriasBase.CrearModeloBusqueda();
            foreach (var persona in sistemas)
            {
                if (persona.CoincideCon(modelo))
                {
                    return persona;
                }
            }

            Console.WriteLine("No se ha encontrado una materia que coincida");
            return null;
        }

        //public static MateriasBase SeleccionarAsignacion(int materia)
        //{
        //    var modelo = MateriasBase.CrearModeloBusquedaAsignacion(materia);
        //    foreach (var persona in sistemas)
        //    {
        //        if (persona.CoincideCon(modelo))
        //        {
        //            return persona;
        //        }
        //    }

        //    Console.WriteLine("No se ha encontrado una materia que coincida");
        //    return null;
        //}
    }
}
