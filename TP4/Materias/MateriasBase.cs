﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class MateriasBase
    {
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public MateriasBase() { }

        public MateriasBase(string linea)
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

        public static List<MateriasBase> materiasDisponibles = new List<MateriasBase>();

        public static MateriasBase CrearModeloBusqueda()
        {
            var modelo = new MateriasBase();
            modelo.CodigoMateria = IngresarCodigoMateria();
            return modelo;
        }

        public static MateriasBase CrearModeloBusquedaAsignacion(int materia, int CantidadMax)
        {
            var modelo = new MateriasBase();
            modelo.CodigoMateria = IngresarCodigoMateriaAsignacion(materia, CantidadMax);
            return modelo;
        }

        public bool CoincideCon(MateriasBase modelo)
        {
            if (modelo.CodigoMateria != 0 && modelo.CodigoMateria != CodigoMateria)
            {
                return false;
            }

            return true;

        }


        //Validaciones e ingresos

        private static int IngresarCodigoMateriaAsignacion(int materia, int CantidadMax)
        {
            var titulo = "Ingrese el codigo de materia ha inscribirse numero " + materia + "/" + CantidadMax;

            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("No ha ingresado un codigo de materia válido");
                    continue;
                }

                if (int.TryParse(ingreso, out var codigomateria) == false)
                {
                    Console.WriteLine("No ha ingresado un codigo de materia válido");
                    continue;
                }

                return codigomateria;

            } while (true);
        }

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

                if (int.TryParse(ingreso, out var codigomateria) == false)
                {
                    Console.WriteLine("No ha ingresado un codigo de materia válido");
                    continue;
                }

                return codigomateria;

            } while (true);
        }


    }
}
