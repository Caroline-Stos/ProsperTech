using Microsoft.Extensions.Configuration;
using RepositorioEntity.Context;
using RepositorioEntity.Models;
using Model.Geladeira;

namespace Servicos
{
    public class GeladeiraService
    {
        private GeladeiraDbContext _contexto;
        IConfiguration _configuration;

        public GeladeiraService(GeladeiraDbContext contexto, IConfiguration configuration)
        {
            _contexto = contexto;
            _configuration = configuration;
        }

        public string AddNovoItem(int container, int posicao, ItemModel itemModel)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {

                    if (itemModel == null)
                    {
                        return "Item não pode ser nulo!";
                    }

                    var itemExistente = _contexto.Items
                        .FirstOrDefault(item => item.NomeItem == itemModel.Nome);

                    if (itemExistente != null)
                    {
                        return "Item já existe na geladeira!";
                    }

                    var containerExistente = _contexto.Containers.SingleOrDefault(cont => cont.ContainerId == container);
                    if (containerExistente == null)
                        return "Container não encontrado!";

                    var posicaoExistente = _contexto.Posicaos.SingleOrDefault(posic => posic.PosicaoId == posicao);
                    if (posicaoExistente == null)
                        return "Posicao não encontrada!";

                    var novoItem = new Item
                    {
                        NomeItem = itemModel.Nome,
                        ContainerId = container,
                        PosicaoId = posicao
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
            var listaItens = new List<Item>();

            try
            {
                listaItens = _contexto.Items.ToList();
                return listaItens;
            }

            catch (Exception)
            {
                return null;
            }

        }

        public Item GetItemById(int itemId)
        {
            var itemEntity = new Item();

            try
            {
                if (itemId > 0)
                {
                    var item = _contexto.Items.Where(x => x.ItemId == itemId).ToList();
                    itemEntity = item?.FirstOrDefault();
                    if (itemEntity != null)
                        return itemEntity;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeletarItem(int itemId)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    if (itemId == null)
                        return "Id não pode ser nulo!";

                    var item = _contexto.Items.SingleOrDefault(it => it.ItemId == itemId);

                    if (item == null)
                        return "Item não encontrado!";

                    _contexto.Items.Remove(item);

                    _contexto.SaveChanges();

                    transaction.Commit();
                    return "Item excluído com sucesso!";

                }
                catch
                {
                    throw new Exception("Erro ao excluir item.");                   
                }
            }

        }

        public string AtualizarNomeItem(ItemModel item)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    if (item == null)
                        return "Item não pode ser nulo!";

                    var itemExistente = _contexto.Items
                    .FirstOrDefault(it => it.ItemId == item.Id);

                    if (itemExistente != null)
                    {
                        itemExistente.NomeItem = item.Nome;
                        //_contexto.Update(itemExistente);
                        _contexto.SaveChanges();

                        transaction.Commit();
                        return "Item alterado com sucesso!";
                    }
                    else
                    {
                        return "Item inválido!";
                    }
                }                
                catch
                {
                    throw new Exception("Erro ao atualizar item.");
                }
            }
        }

        public string EsvaziarContainer(int containerId)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    var containerExistente = _contexto.Containers.SingleOrDefault(cont => cont.ContainerId == containerId);

                    if (containerExistente == null)
                        return "Container não existe!";

                    List<Item> ItensContainer = new List<Item>();

                    var itensList = _contexto.Items.ToList();

                    foreach (var item in itensList)
                    {
                        if (item.ContainerId == containerId)
                            ItensContainer.Add(item);
                    }

                    if (ItensContainer.Count == 0)
                    {
                        return "Não há itens neste container!";
                    }

                    foreach (var item in ItensContainer)
                    {
                        _contexto.Remove(item);
                        _contexto.SaveChanges();
                    }

                    transaction.Commit();
                    return "Container esvaziado com sucesso!";

                }             
                catch
                {
                    throw new Exception("Erro ao tentar esvaziar container.");
                }
            }
        }
    }
}
