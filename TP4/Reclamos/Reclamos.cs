using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Reclamos
{
    class Reclamos
    {

        public static List<Reclamos> reclamosAlumnos = new List<Reclamos>();
        public static int variableNReclamo = 0;

        public int NReclamo { get; set; }
        public int NRegistro { get; set; }
        public string Reclamo { get; set; }
        public string Estado { get; set; }


        public Reclamos() { }

        public Reclamos(string linea)
        {
            var datos = linea.Split('-');
            NReclamo = int.Parse(datos[0]);
            NRegistro = int.Parse(datos[1]);
            Reclamo = (datos[1]);
            Estado = (datos[2]);
        }

        static Reclamos()
        {
            string fileName = "TP4/TXT/Reclamos.txt";
            string basePath = Environment.CurrentDirectory;
            string PathCortada = Strings.Right(basePath, 13);
            basePath = basePath.Replace(PathCortada, "");
            string Reclamos = basePath + fileName;

            if (File.Exists(Reclamos))
            {
                using (var reader = new StreamReader(Reclamos))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var reclamo = new Reclamos(linea);
                        reclamosAlumnos.Add(new Reclamos()
                        {
                            NReclamo = reclamo.NReclamo,
                            NRegistro = reclamo.NRegistro,
                            Reclamo = reclamo.Reclamo,
                            Estado = reclamo.Estado,
                        });
                    }
                }
            }
        }
        public static void AgregarReclamo(int NRegistro, string reclamo)
        {
            /*variableNReclamo = 0;
            foreach (var item in reclamosAlumnos)
            {
                variableNReclamo++;
            }
            */
            reclamosAlumnos.Add(new Reclamos()
            {
                NRegistro = NRegistro,
                NReclamo = variableNReclamo+1,
                Reclamo = reclamo,
                Estado = "PENDIENTE",
            });
            Reclamos.EscribirReclamosEnTXT();
           

        }

        public static void VerReclamosAdministrador()
        {
            foreach (var val in reclamosAlumnos)
            {
                Console.WriteLine("Numero de registro: " + val.NRegistro + " | Descripcion reclamo: " + val.Reclamo + " | Estado: " + val.Estado);
            }
            Console.ReadKey();
        }
        public static void VerReclamosAlumno(int NRegistro)
        {
            foreach (var val in reclamosAlumnos)
            {
                if(val.NRegistro == NRegistro)
                {
                    Console.WriteLine("Numero de reclamo: " + val.NReclamo + "| Numero de registro: " + val.NRegistro + " | Descripcion reclamo: " + val.Reclamo + " | Estado: " + val.Estado);
                }
            }
            Console.ReadKey();
        }

        public static void ActualizarEstadoReclamo(int NReclamo)
        {
            foreach (var item in reclamosAlumnos)
            {
                if(item.NReclamo == NReclamo)
                {
                    item.Estado = "SOLUCIONADO";
                }
            }
        }

        public static void EscribirReclamosEnTXT()
        {
            string fileName = "TP4/TXT/Reclamos.txt";
            string basePath = Environment.CurrentDirectory;
            string PathCortada = Strings.Right(basePath, 13);
            basePath = basePath.Replace(PathCortada, "");
            string Reclamos = basePath + fileName;

            if (File.Exists(Reclamos))
            {
                using (StreamWriter sw = File.AppendText(Reclamos))
                {
                    foreach (var val in reclamosAlumnos)
                    {
                        sw.WriteLine("Numero de reclamo" + val.NReclamo + "-Numero de registro:" + val.NRegistro + "-Descripcion reclamo:" + val.Reclamo + "-Estado:" + val.Estado);
                    }

                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el archivo TXT. El archivo 'Reclamos.txt' debe estar en la carpeta TXT");
            }
        }
    }

}


