using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    class MateriasAprobadasPorAlumno
    {
        public int NRegistro { get; set; }
        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public MateriasAprobadasPorAlumno() { }

        public MateriasAprobadasPorAlumno(string linea)
        {
            var datos = linea.Split('-');
            NRegistro = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            NombreMateria = (datos[2]);
        }

        public string ObtenerLineaDatosAlumno() => $"{NRegistro}-{CodigoMateria}-{NombreMateria}";

        public static MateriasAprobadasPorAlumno CrearModeloBusquedaAlumno(int CodigoPersona)
        {
            var modelo = new MateriasAprobadasPorAlumno();
            modelo.CodigoMateria = CodigoPersona;
            return modelo;
        }


        public bool CoincideConAlumno(MateriasAprobadasPorAlumno modelo)
        {
            if (modelo.NRegistro != 0 && modelo.NRegistro != NRegistro)
            {
                return false;
            }

            return true;

        }

        public static List<MateriasAprobadasPorAlumno> JuampiAprobadas = new List<MateriasAprobadasPorAlumno>();
        private static readonly Dictionary<int, MateriasAprobadasPorAlumno> entradas = new Dictionary<int, MateriasAprobadasPorAlumno>();
        const string nombreArchivo = "MateriasAprobadasAlumnos.txt";

        
        public static void EscribirAprobadasEnTXT()
        {
            if (File.Exists(nombreArchivo))
            {
                using (TextWriter tw = new StreamWriter(nombreArchivo))
                {
                    foreach(var materiaAprobada in JuampiAprobadas)
                    {
                        tw.WriteLine("Numero de registro:" + materiaAprobada.NRegistro +" | Codigo de materia:" + materiaAprobada.CodigoMateria + " | Nombre de materia:" + materiaAprobada.NombreMateria);
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("No encontre el archivo TXT");
            }
        }


        public static void AgregarMateria(int numRegistro, int codMateria, string nomMateria)
        {
            JuampiAprobadas.Add(new MateriasAprobadasPorAlumno()
            {
                NRegistro = numRegistro,
                CodigoMateria = codMateria,
                NombreMateria = nomMateria,
            });
        }

        public static void ImprimirLista()
        {
            Console.WriteLine("Sus Materias aprobadas son: ");
            foreach (var item in JuampiAprobadas)
            {
                //Console.WriteLine($"{JuampiAprobadas.Nro);
            }
        }

        public static void MostrarDatos(int CodigoPersona)
        {
            string Mensaje = "";

            foreach (var persona in entradas.Values)
            {
                if (CodigoPersona == persona.NRegistro)
                {
                    foreach (var materias in entradas.Values)
                    {
                        Mensaje += "Materia disponible: \n" + " - " + $"{materias.NombreMateria}\n";
                    }
                    if (Mensaje != "")
                    {
                        Console.WriteLine(System.Environment.NewLine + Mensaje);
                    }
                    if (Mensaje == "")
                    {
                        Console.WriteLine("No tiene materias disponibles");
                    }
                }
            }
        }

        public static MateriasAprobadasPorAlumno Seleccionar(int CodigoPersona)
        {
            var modelo = CrearModeloBusquedaAlumno(CodigoPersona);
            foreach (var materias in entradas.Values)
            {
                if (materias.CoincideConAlumno(modelo))
                {
                    return materias;
                }
            }

            Console.WriteLine("No se ha encontrado una materia que coincida");
            return null;
        }




    }
}
