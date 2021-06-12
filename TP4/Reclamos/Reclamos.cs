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
            Reclamo = (datos[2]);
            Estado = (datos[3]);
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
        public static void AgregarReclamo(int NReclamo, int NRegistro, string reclamo, string estado)
        {
            foreach (var item in reclamosAlumnos)
            {
                NReclamo++;
            }

            int numeroReclamo = NReclamo + 1;
            
            reclamosAlumnos.Add(new Reclamos()
            {
                NRegistro = NRegistro,
                NReclamo = numeroReclamo,
                Reclamo = reclamo,
                Estado = estado,
            });
            Reclamos.EscribirReclamosEnTXT(numeroReclamo, NRegistro, reclamo, estado);
           

        }

        public static void VerReclamosAdministrador()
        {
            foreach (var val in reclamosAlumnos)
            {
                Console.WriteLine("Numero de reclamo: " + val.NReclamo + "| Numero de registro: " + val.NRegistro + " | Descripcion reclamo: " + val.Reclamo + " | Estado: " + val.Estado);
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

        public static void ActualizarEstadoReclamo()
        {
            VerReclamosAdministrador();

            Console.WriteLine("Cual es el numero de reclamo a actualizar?");
            // PONER VERIFICACION DE QUE EXISTA Y BUCLE
            string respuesta = Console.ReadLine();
            // CAMBIAR POR TRYPARSE Y BUCLE

            foreach (var item in reclamosAlumnos)
            {
                int Nreclamo = int.Parse(respuesta);
                if (item.NReclamo == Nreclamo)
                {
                    item.Estado = "SOLUCIONADO";
                    Console.WriteLine("Numero de reclamo cambiado con exito.");
                    EscribirReclamosEnTXT(item.NReclamo, item.NRegistro, item.Reclamo, item.Estado);                   
                }
            }

            Console.ReadKey();
        }

        public static void EscribirReclamosEnTXT(int Nreclamo, int Nregistro, string reclamo, string estado)
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
                        sw.WriteLine(Nreclamo + "-" + Nregistro + "-" + reclamo + "-" + estado);

                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el archivo TXT. El archivo 'Reclamos.txt' debe estar en la carpeta TXT");
            }
        }
    }

}


