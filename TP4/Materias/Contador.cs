﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Contador
    {
        public static List<MateriasBase> contador = new List<MateriasBase>();

        const string nombreArchivo = "Contador.txt";

        static Contador()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var reader = new StreamReader(nombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var carrera = new MateriasBase(linea);
                        contador.Add(new MateriasBase()
                        {
                            CodigoMateria = carrera.CodigoMateria,
                            NombreMateria = carrera.NombreMateria,
                        });
                    }
                }
            }       
        }

        
        public static void MostrarTXT()
        {
            string Mensaje = "";
            foreach (var materias in contador)
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
            foreach (var persona in contador)
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
        //    foreach (var persona in contador)
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