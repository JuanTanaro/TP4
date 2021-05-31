using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    internal class Program
    {

        //Problemas:
        //Falta hacer un bucle por si no existe el alumno

        static void Main(string[] args)
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("-------------");

                // Iniciacion del usuario. 
                BuscoRegistro();

                // Seleccionamos la carrera
                Console.WriteLine("Seleccione para que carrera va a anotarse a las materias");
                Console.WriteLine("1 - Economia");
                Console.WriteLine("2 - Sistemas");
                Console.WriteLine("3 - Administracion de empresas");
                Console.WriteLine("4 - Actuario en administracion");
                Console.WriteLine("5 - Actuario en economia");
                Console.WriteLine("6 - Contador Publico");

                Console.WriteLine("Seleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarMateriasEconomia();
                        MarcarAprobadas();
                        break;
                    case "2":
                        MostrarMateriasSistemas();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú");
                        break;
                }

            } while (!salir);
        }

        private static void BuscoRegistro()
        {
            var persona = Alumnado.Seleccionar();
            if (persona == null)
            {
                return;
            }
            persona?.Mostrar();
        }

        private static void MostrarMateriasEconomia()
        {
            Economia.MostrarDatos();
        }
        private static void MostrarMateriasSistemas()
        {
            Sistemas.MostrarDatos();
        }

        private static void MarcarAprobadas()
        {
            //string strMateriaAprobada = Console.ReadLine();
            //int CodigoMateriaAprobada = ChequearSiEsNumero(strMateriaAprobada);
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
