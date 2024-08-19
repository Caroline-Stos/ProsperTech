using System;

namespace MeuPrimeiroProjeto.Aula1
{
    internal class clsConvertTemp
    {
        static public void Execute()
        {
            Console.WriteLine("Por favor, insira um número da temperatura:");
            double temp = double.Parse(Console.ReadLine());

            Console.WriteLine("Por favor, insira uma unidade de temperatura (C, K ou F) para ser convertida em Celsius:");
            string unit = Console.ReadLine()?.ToLower();

            switch (unit)
            {
                case "k": // Converte de Kelvin para Celsius
                    temp -= 273.15;
                    break;
                case "f": // Converte de Fahrenheit para Celsius
                    temp = (temp - 32) / 1.8;
                    break;
                case "c": // Se for em Celsius, não há conversão
                    break;
                default:
                    Console.WriteLine("Unidade de temperatura inválida.");
                    return;
            }

            if (temp > 20 && temp < 25)
            {
                Console.WriteLine($"{temp:F2}ºC. Temperatura agradável.");
            }
            else if (temp >= 25)
            {
                Console.WriteLine($"{temp:F2}ºC. Temperatura quente.");
            }
            else
            {
                Console.WriteLine($"{temp:F2}ºC. Temperatura fria.");
            }
        }
    }
}
