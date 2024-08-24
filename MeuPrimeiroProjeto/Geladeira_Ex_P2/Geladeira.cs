using System;
using System.Reflection;

namespace MeuPrimeiroProjeto.Geladeira_Ex_P2
{
    public class Geladeira_P2
    {
        // propriedades

        // Dicionario para poder iterar sobre os andares da geladeira
        public Dictionary<string, Andar> DictAndares = new Dictionary<string, Andar>();
        public Andar CarneAndar { get; set; }
        public Andar LaticAndar { get; set; }
        public Andar FruitAndar { get; set; }

        public Geladeira_P2()
        {
            CarneAndar = new Andar(); // inicializa já com os andares declarados e instanciados
            LaticAndar = new Andar();
            FruitAndar = new Andar();

            DictAndares.Add("CarneAndar", CarneAndar); // Adiciona cada andar no dicionario com uma chave/valor
            DictAndares.Add("LaticAndar", LaticAndar);
            DictAndares.Add("FruitAndar", FruitAndar);

        }

        //metodos - Chama o metodo do objeto container
        public string AddItem(string andar, int container, int posicao, Item item)
        {
            if (DictAndares.ContainsKey(andar)) // Verifica se o andar existe no dicionario de andares
            {
                var containerList = DictAndares[andar].ContainerList; // pega a lista dos containers do andar desejado

                if (container >= 0 && container < containerList.Count) // Verifica se o parametro container esta dentro do range de posicoes possiveis
                    return containerList[container].AddItem(posicao, item); // Adiciona o item criado no container correspondente

                return "Container fora do range.";
            } 
            else
            {
                return "Nome de andar inválido";
            }
        }

        public string RemoverItem(string andar, int container, Item item)
        {
            if (DictAndares.ContainsKey(andar)) // Verifica se o andar existe no dicionario de andares
            {
                var containerList = DictAndares[andar].ContainerList; // 

                if (container >= 0 && container < containerList.Count) //
                    return containerList[container].RemoverItem(item); // Remove o item 

                return "Container fora do range.";
            }
            else
            {
                return "Nome de andar inválido";
            }

        }

        public string LimparContainer(string andar, int container)
        {
            if (DictAndares.ContainsKey(andar)) // Verifica se o andar existe no dicionario de andares
            {
                var containerList = DictAndares[andar].ContainerList; //
                 
                if (container >= 0 && container < containerList.Count) //
                    return containerList[container].LimparContainer();  // limpa o container

                return "Container fora do range.";
            }
            else
            {
                return "Nome de andar inválido";
            }
        }

        public string StatusContainer(string andar, int container)
        {
            if (DictAndares.ContainsKey(andar)) // Verifica se o andar existe no dicionario de andares
            {
                var containerList = DictAndares[andar].ContainerList; //
                if (container >= 0 && container < containerList.Count) //
                    return containerList[container].StatusContainer(); // Retorna o status do container correspondente

                return "Container fora do range.";
            }
            else
            {
                return "Nome de andar inválido";
            }
        }

        public string ListarItens() // metodo para ver todos os itens da geladeira
        {
            var _todosItens = new List<string>(); // Cria uma nova variavel p/ armazenas os itens

            AdicionarItensDeAndar(CarneAndar, _todosItens); // chama a função seguinte para iterar e adicionar os itens à lista _todosItens
            AdicionarItensDeAndar(LaticAndar, _todosItens);
            AdicionarItensDeAndar(FruitAndar, _todosItens);

            return string.Join(", ", _todosItens); // retorna os valores separados por virgula

        }

        // metodo para listar os itens por andar
        private void AdicionarItensDeAndar(Andar andar, List<string> listaDeItens)
        {
            foreach (var container in andar.ContainerList) //
            {
                var itensDoContainer = container.ListarItens(); // retorna uma lista dos itens

                if (itensDoContainer != null && itensDoContainer.Any()) // Verifica se ListarItens retornou os itens;
                {
                    listaDeItens.Add(itensDoContainer); // Adiciona na nova lista
                }
            }
        }
    }
}
