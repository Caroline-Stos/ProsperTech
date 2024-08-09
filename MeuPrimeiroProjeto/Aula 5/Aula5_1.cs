using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroProjeto.Aula_5
{
    internal class Geladeira
    {
        static public void Main()
        {
            List<List<string>> andar_0 = new List<List<string>>();
            List<List<string>> andar_1 = new List<List<string>>();
            List<List<string>> andar_2 = new List<List<string>>();

            // Andar 0 - Hortifruit
            List<string> container_0 = new List<string> { "Maça", "Banana", "Melao", "Uva" };
            List<string> container_1 = new List<string> { "Melancia", "Pera", "Caqui", "Kiwi" };
            andar_0.Add(container_0);
            andar_0.Add(container_1);

            // Andar 1 - Laticinios e Enlatados
            List<string> container_3 = new List<string> { "Queijo", "Leite", "Iogurte", "Requeijao" };
            List<string> container_4 = new List<string> { "Milho", "Atum", "Sardinha", "Ervilha" };
            andar_1.Add(container_3);
            andar_1.Add(container_4);

            // Andar 2 - Charcutaria, carnes e ovos
            List<string> container_5 = new List<string> { "Frango", "Fraudinha", "Salame", "Presunto" };
            List<string> container_6 = new List<string> { "Linguiça", "Carne seca", "Patinho", "Bacon" };
            andar_2.Add(container_5);
            andar_2.Add(container_6);

            ImprimirAlimentos(andar_0);
            ImprimirAlimentos(andar_1);
            ImprimirAlimentos(andar_2);

        }

        static public void ImprimirAlimentos(List<List<string>> andar)
        {
            Console.WriteLine($"Alimentos no andar: ");
            foreach (var container in andar)
            {
                foreach (var alimento in container)
                {
                    Console.WriteLine(alimento);
                }
            }
            Console.WriteLine();
        }
    }
}


