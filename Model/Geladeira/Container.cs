
namespace Model.Geladeira
{
    public class ContainerModel
    {
        //propriedades
        public List<ItemModel> ItensList { get; set; } = new List<ItemModel>(new ItemModel[4]);
        public const int LimiteMax = 4; //container com 4 posições

        //metodos
        public string AddItem(int indice, ItemModel item)
        {
            // Verifica se o índice está dentro dos limites da lista
            if (indice < 0 || indice >= ItensList.Count)
                return "Posição fora dos limites do container.";

            if (ItensList[indice] == null) // Verifica se a posicao(indice) esta vazia
            {
                if (ItensList.Contains(item)) // .. se contem item
                {
                    return $"{item} já existe no container.";
                }
                else if (ItensList.Count > LimiteMax) // ... se ultrapassa o limite maximo de posicoes
                {
                    return $"Container cheio. Adicione {item} no container 2";
                }
                else
                {
                    ItensList[indice] = item; // adiciona o item no indice desejado
                    return $"{item.Nome} adicionado com sucesso.";
                }
            }
            else { return "Já existe um produto nesta posição."; }
        }
        public string RemoverItem(ItemModel item)
        {
            if (!ItensList.Contains(item)) // ... se o item nao existe no container
            {
                return "Este item não contém no container.";
            }
            else
            {
                ItensList.Remove(item); // remove item
                return $"{item.Nome} removido com sucesso.";
            }
        }
        public string LimparContainer() // metodo adicional de esvaziar todo o container
        {
            if (ItensList.Count > 0) // ...se existe algum valor na lista de itens
            {
                ItensList.Clear();
                return "O container foi esvaziado.";
            }
            else
            {
                return "O container está vazio.";
            }
        }
        public string ListarItens() // Método adicional de listar todos os itens
        {
            if (ItensList != null && ItensList.Any()) // Verifica se existe algum item na lista
            {
                var list = new List<string>();

                foreach (var item in ItensList)
                {
                    if (item != null)
                        list.Add($"{item.Id}: {item.Nome}"); // adiciona o item na variavel list
                }

                return string.Join(", ", list);
            }
            else
            {
                return "Geladeira vazia"; // Retorna uma lista vazia se não houver itens
            }
        }

        public string StatusContainer() // metodo adicional de apresentar o status do container (vazio, posições vazias ou cheio)
        {
            var itensPreenchidos = ItensList.Count(item => item != null); // retorna o numero de itens existentes

            if (itensPreenchidos == LimiteMax)
            {
                return "O container está totalmente cheio.";
            }
            else if (itensPreenchidos == 0)
            {
                return "O container está totalmente vazio.";
            }
            else
            {
                var posicoesVazias = 4 - itensPreenchidos;
                return $"O container tem {posicoesVazias} lugar(es) vazio(s).";
            }
        }
    }
}
