using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroProjeto.Geladeira_Ex
{
    internal class Geladeira_Poo
    {
        // propriedades
        public Andar CarneAndar { get; set; } = new Andar();
        public Andar LaticAndar { get; set; } = new Andar();
        public Andar FruitAndar { get; set; } = new Andar();

        //metodos
        public void VerGeladeira()
        {
            var _todosItens = new List<string>();

            AdicionarItensDeAndar(CarneAndar, _todosItens);
            AdicionarItensDeAndar(LaticAndar, _todosItens);
            AdicionarItensDeAndar(FruitAndar, _todosItens);

            Console.WriteLine(string.Join(", ", _todosItens)); 

        }

        private void AdicionarItensDeAndar(Andar andar, List<string> listaDeItens)
        {
            foreach (var container in andar.ContainerList)
            {
                var itensDoContainer = container.ListarItens().ToList(); // Chama o método ListarItens
                if (itensDoContainer != null && itensDoContainer.Any())
                {
                    listaDeItens.AddRange(itensDoContainer);
                }
            }
        }
    }
}
