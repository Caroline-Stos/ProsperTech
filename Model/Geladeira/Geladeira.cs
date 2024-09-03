using System;
using System.Reflection;

namespace Model.Geladeira
{
    public class GeladeiraModel
    {
        // propriedades
       
        public Dictionary<string, AndarModel> DictAndares = new Dictionary<string, AndarModel>();
        public AndarModel CarneAndar { get; set; }
        public AndarModel LaticAndar { get; set; }
        public AndarModel FruitAndar { get; set; }

        public GeladeiraModel()
        {
            CarneAndar = new AndarModel(); // inicializa já com os andares declarados e instanciados
            LaticAndar = new AndarModel();
            FruitAndar = new AndarModel();

            DictAndares.Add("1", CarneAndar); // Adiciona cada andar no dicionario com uma chave/valor
            DictAndares.Add("2", LaticAndar);
            DictAndares.Add("3", FruitAndar);

        }

        //metodos - Chama o metodo do objeto container
        public string AddItem(string andar, int container, int posicao, ItemModel item)
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

        public string RemoverItem(string andar, int container, ItemModel item)
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
        private void AdicionarItensDeAndar(AndarModel andar, List<string> listaDeItens)
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
