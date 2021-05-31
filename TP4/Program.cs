using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creacion de dictionary para almacenar registro y carrera (por ahora)
            IDictionary<int, string> Alumnos = new Dictionary<int, string>();

            //Creacion de dictionaries para cada carrera
            /*
            IDictionary<int, string> Economia = new Dictionary<int, string>();
            IDictionary<int, string> Sistemas = new Dictionary<int, string>();
            IDictionary<int, string> Administracion = new Dictionary<int, string>();
            IDictionary<int, string> ActuarioAdm = new Dictionary<int, string>();
            IDictionary<int, string> ActuarioEcon = new Dictionary<int, string>();
            IDictionary<int, string> Contador = new Dictionary<int, string>();
            */

            // Iniciacion del usuario
            Console.WriteLine("¿Cual es su numero de registro?");
            string strNumeroRegistro = Console.ReadLine();
            int NumeroRegistro = ChequearSiEsNumero(strNumeroRegistro);

            Console.WriteLine("Seleccione para que carrera va a anotarse a las materias");
            Console.WriteLine("1 - Economia");
            Console.WriteLine("2 - Sistemas");
            Console.WriteLine("3 - Administracion de empresas");
            Console.WriteLine("4 - Actuario en administracion");
            Console.WriteLine("5 - Actuario en economia");
            Console.WriteLine("6 - Contador Publico");
            string strEleccionCarrera = Console.ReadLine();
            ListarMaterias(strEleccionCarrera);

            //Agrego al alumno a la base
            Alumnos.Add(NumeroRegistro, strEleccionCarrera);

            // Permito al usuario seleccionar las materias que ya realizo
            Console.WriteLine("Seleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");
            bool continuar = true;
            string strMateriaAprobada = Console.ReadLine();
            int CodigoMateriaAprobada = ChequearSiEsNumero(strMateriaAprobada);
            //RemoverMaterias(strEleccionCarrera, CodigoMateriaAprobada);
            
            //while (continuar == true)
            //{
            //    Console.WriteLine("Ingrese otro codigo o escriba 'SALIR'");
            //    strMateriaAprobada = Console.ReadLine();
            //    if (strMateriaAprobada == "SALIR")
            //    {
            //        continuar = false;
            //    }
            //    else
            //    {
            //        CodigoMateriaAprobada = ChequearSiEsNumero(strMateriaAprobada);
            //        RemoverMaterias(strEleccionCarrera, CodigoMateriaAprobada);
            //        continuar = true;
            //    }

            //}
        }

        // Metodo para validar si lo ingresado es un numero
        public static int ChequearSiEsNumero(string strNumeroRegistro)
        {
            int NumeroRegistro;
            while(int.TryParse(strNumeroRegistro, out NumeroRegistro) == false)
            {
                Console.WriteLine("El valor ingresado no es un numero. Intente nuevamente");
            }
            return NumeroRegistro;
        }


        //Metodo para listar todas las materias de cada carrera. Cada uno de estos case deberia imprimir el contenido del dictionary
        public static void ListarMaterias(string eleccion)
        {
            switch (eleccion)
            {
                case "1":
                    MostrarMateriasEconomia();
                    break;
                default:
                    Console.WriteLine("No ha ingresado una opción del menú");
                    break;
            }
        }

        private static void MostrarMateriasEconomia()
        {
            Carrera.MostrarDatos();
        }

        //public static void RemoverMaterias(string eleccionCarrera, int CodigoMateria)
        //{
        //    switch (eleccionCarrera)
        //    {
        //        case 1:
        //            Economia.Remove(CodigoMateria);
        //            break;

        //        case 2:
        //            Sistemas.Remove(CodigoMateria);
        //            break;

        //        case 3:
        //            Administracion.Remove(CodigoMateria);
        //            break;

        //        case 4:
        //            ActuarioAdm.Remove(CodigoMateria);
        //            break;

        //        case 5:
        //            ActuarioEcon.Remove(CodigoMateria);
        //            break;

        //        case 6:
        //            Contador.Remove(CodigoMateria);
        //            break;
        //    }
        //}


    }
}
