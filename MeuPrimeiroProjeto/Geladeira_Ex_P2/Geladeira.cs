using System;
using System.Reflection;

namespace MeuPrimeiroProjeto.Geladeira_Ex_P2
{
    public class Geladeira_P2
    {
        // propriedades
        public Dictionary<string, Andar> DictAndares = new Dictionary<string, Andar>();
        public Andar CarneAndar { get; set; }
        public Andar LaticAndar { get; set; }
        public Andar FruitAndar { get; set; }

        public Geladeira_P2()
        {
            CarneAndar = new Andar(); // inicializa já com os andares declarados e instanciados
            LaticAndar = new Andar();
            FruitAndar = new Andar();

            DictAndares.Add("CarneAndar", CarneAndar);
            DictAndares.Add("LaticAndar", LaticAndar);
            DictAndares.Add("FruitAndar", FruitAndar);

        }

        //metodos
        public string AddItem(string andar, int container, int posicao, Item item)
        {
            if (DictAndares.ContainsKey(andar)) // Verifica se o andar existe no dicionario de andares
            {
                var containerList = DictAndares[andar].ContainerList;

                if (container >= 0 && container < containerList.Count)
                    //adiciona o item
                    return containerList[container].AddItem(posicao, item);

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
                var containerList = DictAndares[andar].ContainerList;

                if (container >= 0 && container < containerList.Count)
                    //remove o item
                    return containerList[container].RemoverItem(item);

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
                var containerList = DictAndares[andar].ContainerList;
                if (container >= 0 && container < containerList.Count)
                    // limpa o container
                    return containerList[container].LimparContainer();

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
                var containerList = DictAndares[andar].ContainerList;
                if (container >= 0 && container < containerList.Count)
                    // status do container
                    return containerList[container].StatusContainer();

                return "Container fora do range.";
            }
            else
            {
                return "Nome de andar inválido";
            }
        }

        public string ListarItens() // metodo para ver todos os itens da geladeira
        {
            var _todosItens = new List<string>();

            AdicionarItensDeAndar(CarneAndar, _todosItens);
            AdicionarItensDeAndar(LaticAndar, _todosItens);
            AdicionarItensDeAndar(FruitAndar, _todosItens);

            return string.Join(", ", _todosItens);

        }

        // metodo para listar os itens por andar
        private void AdicionarItensDeAndar(Andar andar, List<string> listaDeItens)
        {
            foreach (var container in andar.ContainerList)
            {
                var itensDoContainer = container.ListarItens(); // retorna uma lista dos itens
                if (itensDoContainer != null && itensDoContainer.Any())
                {
                    listaDeItens.Add(itensDoContainer);
                }
            }
        }
    }
}
