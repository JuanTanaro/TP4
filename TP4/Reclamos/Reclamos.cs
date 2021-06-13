using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Reclamos
    {

        public static List<Reclamos> AllreclamosAlumnos = new List<Reclamos>();
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
            string fileName = "TP4/TXT/Reclamos/Reclamos.txt";
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
                        AllreclamosAlumnos.Add(new Reclamos()
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

        
        public static void VerReclamosAdministrador()
        {
            foreach (var val in AllreclamosAlumnos)
            {
                Console.WriteLine("Numero de reclamo: " + val.NReclamo + "| Numero de registro: " + val.NRegistro + " | Descripcion reclamo: " + val.Reclamo + " | Estado: " + val.Estado);
            }
            
        }

        public static void VerReclamosAlumno(int NRegistro)
        {
            Console.WriteLine("Tiene los siguientes reclamos a su nombre: ");

            foreach (var val in AllreclamosAlumnos)
            {
                if(val.NRegistro == NRegistro)
                {
                    Console.WriteLine("Numero de reclamo: " + val.NReclamo + "| Numero de registro: " + val.NRegistro + " | Descripcion reclamo: " + val.Reclamo + " | Estado: " + val.Estado);
                }
            }
        }

        public static void RealizarReclamo(int CodigoPersona)
        {
            Console.WriteLine("¿Cual es el reclamo que desea realizar?");
            string reclamo = Console.ReadLine();
            int numeroReclamo = 0;
            string estado = "PENDIENTE";
            AgregarReclamo(numeroReclamo, CodigoPersona, reclamo, estado);


            Console.WriteLine("Reclamo registrado. Puede ver el estado del mismo desde el menu principal");
        }


        public static void AgregarReclamo(int NReclamo, int NRegistro, string reclamo, string estado)
        {
            foreach (var item in AllreclamosAlumnos)
            {
                NReclamo++;
            }

            int numeroReclamo = NReclamo + 1;

            AllreclamosAlumnos.Add(new Reclamos()
            {
                NRegistro = NRegistro,
                NReclamo = numeroReclamo,
                Reclamo = reclamo,
                Estado = estado,
            });

            EscribirReclamosEnTXT(numeroReclamo, NRegistro, reclamo, estado);

        }

        // Reclamos
        public static Reclamos Seleccionar()
        {
            var modelo = CrearModeloBusqueda();
            foreach (var reclamo in AllreclamosAlumnos)
            {
                if (reclamo.CoincideCon(modelo))
                {
                    return reclamo;
                }
            }

            Console.WriteLine("No se ha encontrado un reclamo que coincida");
            return null;
        }

        public static Reclamos CrearModeloBusqueda()
        {
            var modelo = new Reclamos();
            modelo.NReclamo = NumeroReclamo(obligatorio: false);
            return modelo;
        }

        public bool CoincideCon(Reclamos modelo)
        {
            if (modelo.NReclamo != 0 && modelo.NReclamo != NReclamo)
            {
                return false;
            }
            return true;

        }


        public static void ActualizarEstadoReclamo()
        {
            var reclamo = Seleccionar();
            if (reclamo == null)
            {
                ActualizarEstadoReclamo();
            }

            Console.WriteLine("\nNumero de reclamo: " + $"{reclamo.NReclamo}" + " Numero de registro: " + $"{reclamo.NRegistro}" + " Reclamo: " + $"{reclamo.Reclamo}" + " Estado: " + $"{reclamo.Estado}");

            Console.WriteLine($"Presionar S para marcar como solucionado el reclamo {reclamo.NReclamo}, o N para volver al menu\n");
            var key = Console.ReadLine();
            if (key.ToUpper() == "S")
            {

                BorrarSolucionadosEnTXT(reclamo.NReclamo, reclamo.NRegistro, reclamo.Reclamo, reclamo.Estado);
                Console.WriteLine("\nNumero de reclamo: " + $"{reclamo.NReclamo}" + " Numero de registro: " + $"{reclamo.NRegistro}" + " Reclamo: " + $"{reclamo.Reclamo}" + " Estado: " + "SOLUCIONADO");

                

                foreach (var item in AllreclamosAlumnos)
                {
                    if (item.NReclamo == reclamo.NReclamo)
                    {
                        item.Estado = "SOLUCIONADO";
                        
                        EscribirReclamosEnTXT(item.NReclamo, item.NRegistro, item.Reclamo, item.Estado);
                       
                    }
                }

                Console.WriteLine("\nNumero de reclamo cambiado con exito.");
            }
            else
            {
                Console.WriteLine($"\n{reclamo.NReclamo} NO ha sido marcado como solucionado");

            }
        }

        public static void EscribirReclamosEnTXT(int Nreclamo, int Nregistro, string reclamo, string estado)
        {
            string fileName = "TP4/TXT/Reclamos/Reclamos.txt";
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

        public static void BorrarSolucionadosEnTXT(int Nreclamo, int Nregistro, string reclamo, string estado)
        {
            string fileName = "TP4/TXT/Reclamos/Reclamos.txt";
            string basePath = Environment.CurrentDirectory;
            string PathCortada = Strings.Right(basePath, 13);
            basePath = basePath.Replace(PathCortada, "");
            string reclamos = basePath + fileName;

            if (File.Exists(reclamos))
            {
                string Variable = (Nreclamo + "-" + Nregistro + "-" + reclamo + "-" + estado);

                using (StreamReader sw = new StreamReader(reclamos))
                {
                    string s = "";
                    while ((s = sw.ReadLine()) == Variable)
                    {
                      s.Replace(Variable, "");
                    }
                }
            }
            else
            {
                Console.WriteLine("No se ha encontrado el archivo TXT. El archivo 'Reclamos.txt' debe estar en la carpeta TXT");
            }
        }


        // Validaciones
        private static int NumeroReclamo(bool obligatorio = true)
        {
            var titulo = "\n¿Cual es el numero de reclamo a actualizar?";

            do
            {
                Console.WriteLine(titulo);
                var ingreso = Console.ReadLine();
                if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                {
                    return 0;
                }

                if (!int.TryParse(ingreso, out var reclamo))
                {
                    Console.WriteLine("No ha ingresado un numero de reclamo válido");
                    continue;
                }

                return reclamo;

            } while (true);
        }
    }
}


