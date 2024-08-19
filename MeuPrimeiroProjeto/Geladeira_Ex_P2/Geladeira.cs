using System;

namespace MeuPrimeiroProjeto.Geladeira_Ex
{
    internal class Geladeira_P2
    {
        // propriedades
        public Andar CarneAndar { get; set; } = new Andar(); // inicializa já com os andares declarados e instanciados
        public Andar LaticAndar { get; set; } = new Andar();
        public Andar FruitAndar { get; set; } = new Andar();

        //metodos
        public void VerGeladeira() // metodo para ver todos os itens da geladeira
        {
            var _todosItens = new List<string>();

            AdicionarItensDeAndar(CarneAndar, _todosItens);
            AdicionarItensDeAndar(LaticAndar, _todosItens);
            AdicionarItensDeAndar(FruitAndar, _todosItens);

            //Console.WriteLine(string.Join(", ", _todosItens)); 

        }

        private void AdicionarItensDeAndar(Andar andar, List<string> listaDeItens)
        {
            foreach (var container in andar.ContainerList)
            {
                var itensDoContainer = container.ListarItens(); // retorna uma lista dos itens
                if (itensDoContainer != null && itensDoContainer.Any())
                {
                    listaDeItens.AddRange(itensDoContainer);
                }
            }
        }
    }
}
