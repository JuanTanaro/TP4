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

                var eleccionCarrera = Console.ReadLine();

                switch (eleccionCarrera)
                {
                    case "1":
                        MostrarMateriasEconomia();
                        BajaEconomia();
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
                BuscoRegistro();
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

        private static void BajaEconomia()
        {
            Console.WriteLine("Seleccione las materias que ya realizo escribiendo cada uno de los codigos de materia y luego ENTER");
            var materia = Economia.Seleccionar();
            if (materia == null)
            {
                return;
            }
            materia.Mostrar();
            Console.WriteLine($"Se dispone a dar de baja a {materia.CodigoMateria}. Está ud. seguro? S/N");
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.S)
            {
                Economia.Baja(materia);
                Console.WriteLine($"{materia.NombreMateria} ha sido dada de baja");
            }

            EliminarMateria();
        }

        private static void EliminarMateria()
        {
            bool salir = false;
            do
            {
                Console.WriteLine("¿Tiene otra materia aprobada?");
                Console.WriteLine("1 - SI");
                Console.WriteLine("2 - NO");

                var respuesta = Console.ReadLine();

                switch (respuesta)
                {
                    case "1":
                        BajaEconomia();
                        break;
                    case "2":
                        MostrarMateriasEconomia();
                        Inscripcion();
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

        private static void Inscripcion()
        {
            //var inscripcion = Inscripcion
            //Agenda.Agregar(persona);
        }
    }
}
