﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Inscripciones
    {
        public int NRegistro { get; set; }
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public Inscripciones() { }

        public Inscripciones(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            NombreMateria = (datos[2]);
        }

        public static List<Inscripciones> AlumnoInscripto = new List<Inscripciones>();
        const string nombreArchivo = "Inscripciones.txt";
        

        public void MostrarMateriasDisponibles(int CodigoPersona)
        {
            //var result = Economia.Except(MateriasAprobadasPorAlumno.JuampiAprobadas);

            //Economia.economia.Except<>


            foreach (var materiasAprobadas in Economia.economia)
            {
                var materiaAprobada = materiasAprobadas.CodigoMateria;

                foreach (var totalMaterias in MateriasAprobadasPorAlumno.JuampiAprobadas)
                {
                    if (materiaAprobada != totalMaterias.CodigoMateria)
                    {
                        Console.WriteLine("Codigo de materia:" + totalMaterias.CodigoMateria + " | Nombre de materia:" + totalMaterias.NombreMateria);
                        continue;
                    }
                }
            }

        }

        public static void AgregarInscripcionEnLista(int numRegistro, int codMateria, string nomMateria)
        {
            AlumnoInscripto.Add(new Inscripciones()
            {
                NRegistro = numRegistro,
                CodigoMateria = codMateria,
                NombreMateria = nomMateria,

            });
        }

        public static void EscribirAprobadasEnTXT()
        {
            if (File.Exists(nombreArchivo))
            {
                using (TextWriter tw = new StreamWriter(nombreArchivo))
                {
                    foreach (var materiaAprobada in MateriasAprobadasPorAlumno.JuampiAprobadas)
                    {
                        tw.WriteLine("Numero de registro:" + materiaAprobada.NRegistro + "| Codigo de materia:" + materiaAprobada.CodigoMateria + "| Nombre de materia:" + materiaAprobada.NombreMateria);
                    }

                }
            }
            else
            {
                Console.WriteLine("No encontre el archivo TXT");
            }
        }


    }
}