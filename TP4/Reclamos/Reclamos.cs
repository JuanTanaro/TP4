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
        public static List<Reclamos> reclamosAlumnosSolucionados = new List<Reclamos>();
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

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("\nNumero de reclamo: " + $"{NReclamo}" + " Numero de registro: " + $"{NRegistro}" + " Reclamo: " + $"{Reclamo}" + " Estado: " + $"{Estado}");
            Console.WriteLine();
        }

        public static void ActualizarEstadoReclamo()
        {
            var NumeroDeReclamo = Seleccionar();
            if (NumeroDeReclamo == null)
            {
                ActualizarEstadoReclamo();
            }
            NumeroDeReclamo?.Mostrar();
            

            foreach (var item in AllreclamosAlumnos)
            {
                if (item.NReclamo == NumeroDeReclamo.NReclamo)
                {
                    item.Estado = "SOLUCIONADO";
                    Console.WriteLine("Numero de reclamo cambiado con exito.");
                    
                    EscribirReclamosSolucionadosEnTXT(item.NReclamo, item.NRegistro, item.Reclamo, item.Estado);                   
                }
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

        public static void EscribirReclamosSolucionadosEnTXT(int Nreclamo, int Nregistro, string reclamo, string estado)
        {
            string fileName = "TP4/TXT/Reclamos/ReclamosSolucionados.txt";
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


