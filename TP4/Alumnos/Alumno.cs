﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Alumno
    {
        public int NRegistro { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public double Ranking { get; set; }

        public Alumno() { }

        public Alumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            NombreAlumno = (datos[1]);
            ApellidoAlumno = (datos[2]);
            Ranking = double.Parse(datos[3]);
        }

        public static List<Alumno> alumnos = new List<Alumno>();

        static Alumno()
        {
            string fileName = "TP4/TXT/Alumno.txt";
            string basePath = Environment.CurrentDirectory;
            string PathCortada = Strings.Right(basePath, 13);
            basePath = basePath.Replace(PathCortada, "");
            string Alumno = basePath + fileName;

            if (File.Exists(Alumno))
            {
                using (var reader = new StreamReader(Alumno))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var alumno = new Alumno(linea);
                        alumnos.Add(new Alumno()
                        {
                            NRegistro = alumno.NRegistro,
                            NombreAlumno = alumno.NombreAlumno,
                            ApellidoAlumno = alumno.ApellidoAlumno,
                            Ranking = alumno.Ranking,
                        });
                    }
                }
            }
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("Hola! " + $"{NombreAlumno.Trim()}{ApellidoAlumno}");
            Console.WriteLine();
        }

        public static Alumno Seleccionar()
        {
            var modelo = CrearModeloBusqueda();
            foreach (var persona in alumnos)
            {
                if (persona.CoincideCon(modelo))
                {
                    return persona;
                }
            }

            Console.WriteLine("No se ha encontrado un alumno que coincida");
            return null;
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

            do
            {
                Console.WriteLine();
                Console.WriteLine("-------------");
                Console.WriteLine("INGRESAR");
                Console.WriteLine("-------------");
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var numeroRegistro))
                {
                    Console.WriteLine("No ha ingresado un numero de registro válido");
                    continue;
                }

                return numeroRegistro;

            } while (true);
        }
    }
}
