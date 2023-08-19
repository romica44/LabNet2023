using System;


namespace Practica2ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 1:");
            Ejercicio1();

            Console.WriteLine("\nEjercicio 2:");
            Ejercicio2();

            Console.WriteLine("\nEjercicio 3:");
            Ejercicio3();

            Console.WriteLine("\nEjercicio 4:");
            Ejercicio4();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
        static void Ejercicio1()
        {
            Console.Write("Ingrese un número: ");
            string input = Console.ReadLine();

            try
            {
                int valor = int.Parse(input);
                int resultado = valor / 0;
                Console.WriteLine($"Resultado: {resultado}\nOperación exitosa.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("¡Error: División por cero!\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"¡Error: {ex.Message}!");
            }
        }

        static void Ejercicio2()
        {
            Console.Write("Ingrese el dividendo: ");
            string inputDividendo = Console.ReadLine();
            Console.Write("Ingrese el divisor: ");
            string inputDivisor = Console.ReadLine();

            try
            {
                double dividendo = double.Parse(inputDividendo);
                double divisor = double.Parse(inputDivisor);

                if (divisor == 0)
                {
                    throw new DivideByZeroException("¡Solo Chuck Norris divide por cero!");
                }

                double resultado = dividendo / divisor;
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("¡Seguro ingresaste una letra o no ingresaste nada!");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"¡Error: {ex.Message}!");
            }
        }

        static void Ejercicio3()
        {
            try
            {
                Classes.Logic.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"¡Error: {ex.Message}!\nTipo de excepción: {ex.GetType()}");
            }
        }

        static void Ejercicio4()
        {
            try
            {
                Classes.Logic.ThrowCustomException("Excepcion personalizada");
            }
            catch (Classes.CustomException ex)
            {
                Console.WriteLine($"¡Error: {ex.Message}!\nTipo de excepción: {ex.GetType()}");
            }
        }
    }
}
