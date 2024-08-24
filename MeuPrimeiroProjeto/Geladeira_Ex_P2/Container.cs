using System;
using static iTextSharp.text.pdf.AcroFields;

namespace MeuPrimeiroProjeto.Geladeira_Ex_P2
{
    public class Container
    {
        //propriedades
        public List<string> ItensList { get; set; } = new List<string>(new string[4]);
        public const int LimiteMax = 4; //container com 4 posições

        //metodos
        public string AddItem(int indice, string item)
        {
            // Verifica se o índice está dentro dos limites da lista
            if (indice < 0 || indice >= ItensList.Count)
                return "Posição fora dos limites do container.";

            if (string.IsNullOrEmpty(ItensList[indice]))
            {
                if (ItensList.Contains(item))
                {
                    return $"{item} já existe no container.";
                }
                else if (ItensList.Count > LimiteMax)
                {
                    return $"Container cheio. Adicione {item} no container 2";
                }
                else
                {
                    ItensList[indice] = item;
                    return $"{item} adicionado com sucesso.";
                }
            }
            else { return "Já existe um produto nesta posição."; }
        }
        public string RemoverItem(string item) 
        {
            if (!ItensList.Contains(item)) {
                return "Este item não contém no container.";
            }
            else
            {
                ItensList.Remove(item);
                return $"{item} removido com sucesso.";
            }
        }
        public string LimparContainer() // metodo adicional de esvaziar todo o container
        {
            if (ItensList.Count > 0)
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
            if (ItensList != null && ItensList.Any())
            {
                // Filtra os itens que não são nulos ou vazios
                var itensFiltrados = ItensList.Where(indice => !string.IsNullOrEmpty(indice)).ToList();

                // Concatena os itens em uma única string, separados por vírgula
                return string.Join(", ", itensFiltrados);
            }
            else
            {
                return string.Empty; // Retorna uma string vazia se não houver itens
            }
        }

        public string StatusContainer() // metodo adicional de apresentar o status do container (vazio, posições vazias ou cheio)
        {
            var itensPreenchidos = ItensList.Count(indice => !string.IsNullOrEmpty(indice));
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
