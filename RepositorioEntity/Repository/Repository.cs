using Microsoft.Extensions.Configuration;
using Model.Geladeira;
using RepositorioEntity.Context;
using RepositorioEntity.Interfaces;
using RepositorioEntity.Models;

namespace RepositorioEntity.Repository
{
    public class GeladeiraRepository : IRepository<ItemModel>
    {
        private GeladeiraDbContext _contexto;
        IConfiguration _configuration;

        public GeladeiraRepository(GeladeiraDbContext contexto, IConfiguration configuration)
        {
            _contexto = contexto;
            _configuration = configuration;
        }

        public string AddNovoItem(int containerId, int posicaoId, ItemModel itemModel)
        {
            if (itemModel == null)
            {
                return "Item não pode ser nulo!";
            }

            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    // Verifica se o item já existe na geladeira
                    var itemExistente = _contexto.Items.FirstOrDefault(item => item.NomeItem == itemModel.Nome);
                    if (itemExistente != null)
                    {
                        return "Item já existe na geladeira!";
                    }

                    // Verifica se o container existe
                    var containerExistente = _contexto.Containers.SingleOrDefault(cont => cont.ContainerId == containerId);
                    if (containerExistente == null)
                    {
                        return "Container não encontrado!";
                    }

                    // Verifica se a posição existe
                    var posicaoExistente = _contexto.Posicaos.SingleOrDefault(posic => posic.PosicaoId == posicaoId);
                    if (posicaoExistente == null)
                    {
                        return "Posição não encontrada!";
                    }

                    // Cria um novo item
                    var novoItem = new Item
                    {
                        NomeItem = itemModel.Nome,
                        ContainerId = containerId,
                        PosicaoId = posicaoId
                    };

                    _contexto.Items.Add(novoItem);
                    _contexto.SaveChanges();
                    transaction.Commit();

                    return "Item adicionado com sucesso!";
                }
                catch (Exception ex)
                {
                    return $"Erro: {ex.Message}";
                }
            }
        }

        public List<Item> GetListarItens()
        {
            try
            {
                return _contexto.Items.ToList();
            }
            catch (Exception)
            {
                return new List<Item>(); // Retorna uma lista vazia em caso de erro
            }
        }

        public Item GetItemById(int itemId)
        {
            try
            {
                if (itemId <= 0)
                {
                    return null;
                }

                var item = _contexto.Items.FirstOrDefault(x => x.ItemId == itemId);

                return item; // Retorna o item encontrado ou null se não houver
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string DeletarItem(int itemId)
        {
            if (itemId <= 0)
            {
                return "Id inválido!";
            }

            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    var item = _contexto.Items.SingleOrDefault(it => it.ItemId == itemId);

                    if (item == null)
                    {
                        return "Item não encontrado!";
                    }

                    // Remove o item encontrado
                    _contexto.Items.Remove(item);
                    _contexto.SaveChanges();
                    transaction.Commit();

                    return "Item excluído com sucesso!";
                }
                catch (Exception ex)
                {
                    return $"Erro ao excluir item: {ex.Message}";
                }
            }
        }


        public string AtualizarNomeItem(ItemModel item)
        {
            if (item == null || item.Id <= 0)
            {
                return "Item inválido!";
            }

            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    var itemExistente = _contexto.Items.FirstOrDefault(it => it.ItemId == item.Id);

                    if (itemExistente != null)
                    {
                        // Atualiza o nome do item
                        itemExistente.NomeItem = item.Nome;
                        _contexto.SaveChanges();

                        transaction.Commit();
                        return "Item alterado com sucesso!";
                    }
                    else
                    {
                        return "Item não encontrado!";
                    }
                }
                catch (Exception ex)
                {
                    return $"Erro ao atualizar item: {ex.Message}";
                }
            }
        }


        public string EsvaziarContainer(int containerId)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    // Verifica se o container existe
                    var containerExistente = _contexto.Containers.SingleOrDefault(cont => cont.ContainerId == containerId);

                    if (containerExistente == null)
                        return "Container não existe!";

                    // Busca todos os itens que pertencem ao container
                    var itensContainer = _contexto.Items.Where(item => item.ContainerId == containerId).ToList();

                    if (itensContainer.Count == 0)
                    {
                        return "Não há itens neste container!";
                    }

                    // Remove todos os itens encontrados
                    _contexto.Items.RemoveRange(itensContainer);
                    _contexto.SaveChanges();

                    transaction.Commit();
                    return "Container esvaziado com sucesso!";
                }
                catch (Exception ex)
                {
                    return $"Erro ao tentar esvaziar container: {ex.Message}";
                }
            }
        }
    }
}

