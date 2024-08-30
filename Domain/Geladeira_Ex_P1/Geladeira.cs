using System;

namespace Model.Geladeira_Ex_P1
{
    public class Geladeira_P1
    {
        static public void Main()
        {
            // Instanciando dicionário
            Dictionary<string, List<string[]>> Dicionario = new Dictionary<string, List<string[]>>();

            // Declarando os containers
            string[] fruits_cont0 = new string[] { "Maçã", "Pera", "Laranja", "Uva" };
            string[] fruits_cont1 = new string[] { "Mamão", "Melão", "Mexerica", "Caqui" };

            string[] laticinios_cont2 = new string[] { "Queijo", "Leite", "Iogurte", "Requeijão" };
            string[] laticinios_cont3 = new string[] { "Milho", "Atum", "Sardinha", "Ervilha" };

            string[] carnes_cont4 = new string[] { "Frango", "Fraudinha", "Salame", "Presunto" };
            string[] carnes_cont5 = new string[] { "Linguiça", "Carne seca", "Patinho", "Bacon" };

            // Adicionando os containers em listas por andares
            List<string[]> andar_0 = new List<string[]> { fruits_cont0, fruits_cont1 };
            List<string[]> andar_1 = new List<string[]> { laticinios_cont2, laticinios_cont3 };
            List<string[]> andar_2 = new List<string[]> { carnes_cont4, carnes_cont5 };

            // Adicionando os andares no dicionário - geladeira
            Dicionario.Add("Andar 0", andar_0);
            Dicionario.Add("Andar 1", andar_1);
            Dicionario.Add("Andar 2", andar_2);

            // Exibindo os itens da geladeira
            foreach (var andar in Dicionario)
            {
                Console.WriteLine($"{andar.Key}:");
                foreach (var container in andar.Value)
                {
                    Console.WriteLine($"  * {string.Join(", ", container)}");
                }
            }
        }
    }
}
