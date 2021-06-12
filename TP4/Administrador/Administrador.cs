using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class Administrador
    {
        public int ID { get; set; }
        public string NombreAdmin { get; set; }

        public Administrador() { }

        public Administrador(string linea)
        {
            var datos = linea.Split('-');
            ID = int.Parse(datos[0]);
            NombreAdmin = (datos[1]);
        }

        public static List<Administrador> administrador = new List<Administrador>();

        static Administrador()
        {
            string fileName = "TP4/TXT/Administrador.txt";
            string basePath = Environment.CurrentDirectory;
            string PathCortada = Strings.Right(basePath, 13);
            basePath = basePath.Replace(PathCortada, "");

            string Admin = basePath + fileName;

            if (File.Exists(Admin))
            {
                using (var reader = new StreamReader(Admin))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var admin = new Administrador(linea);
                        administrador.Add(new Administrador()
                        {
                            ID = admin.ID,
                            NombreAdmin = admin.NombreAdmin,
                        });
                    }
                }
            }
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("Hola! " + $"{NombreAdmin.Trim()}");
            Console.WriteLine();
        }

        public static Administrador Seleccionar()
        {
            var modelo = CrearModeloBusqueda();
            foreach (var persona in administrador)
            {
                if (persona.CoincideCon(modelo))
                {
                    return persona;
                }
            }

            Console.WriteLine("No se ha encontrado un administrador que coincida");
            return null;
        }

        public static Administrador CrearModeloBusqueda()
        {
            var modelo = new Administrador();
            modelo.ID = IngresarID(obligatorio: false);
            return modelo;
        }

        public bool CoincideCon(Administrador modelo)
        {
            if (modelo.ID != 0 && modelo.ID != ID)
            {
                return false;
            }
            return true;

        }

        //Validaciones e ingresos

        private static int IngresarID(bool obligatorio = true)
        {
            var titulo = "¿Cual es su ID?";

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
                    Console.WriteLine("No ha ingresado una ID válida");
                    continue;
                }

                return numeroRegistro;

            } while (true);
        }
    }
}
