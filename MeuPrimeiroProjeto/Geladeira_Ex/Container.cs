using System;

namespace MeuPrimeiroProjeto.Geladeira_Ex
{
    internal class Container
    {
        //propriedades
        public List<string> ItensList { get; set; } = new List<string>(new string[4]);

        //metodos
        public void AddItem(int indice, string item)
        {
            if (string.IsNullOrEmpty(ItensList[indice]))
            {
                if (ItensList.Contains(item))
                {
                    Console.WriteLine($"{item} já existe no container.");
                }
                else
                {
                    ItensList[indice] = item;
                    Console.WriteLine($"{item} adicionado com sucesso.");
                }
            }
            else { Console.WriteLine("Já existe um produto nesta posição."); }
        }
        public void RemoverItem(string item)
        {
            ItensList.Remove(item);
            Console.WriteLine($"{item} removido com sucesso.");
        }
        public void LimparContainer()
        {
            if (ItensList.Count > 0)
            {
                ItensList.Clear();
                Console.WriteLine("O container foi esvaziado.");
            }
            else
            {
                Console.WriteLine("O container está vazio.");
            }
        }
        public List<string> ListarItens()
        {
            ItensList = ItensList.Where(i => !string.IsNullOrEmpty(i)).ToList();
            foreach (string item in ItensList)
            {
                Console.WriteLine(item + ", ");
            }
            return ItensList;
        }
        public void StatusContainer()
        {
            var itensPreenchidos = ItensList.Count(i => !string.IsNullOrEmpty(i));
            if (itensPreenchidos == 4)
            {
                Console.WriteLine("O container está cheio.");
            }
            else if (itensPreenchidos == 0)
            {
                Console.WriteLine("O container está vazio.");
            }
            else
            {
                var posicoesVazias = 4 - itensPreenchidos;
                Console.WriteLine($"O container tem {posicoesVazias} lugar(es) vazio(s).");
            }
        }
    }
}
