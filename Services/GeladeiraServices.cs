using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositorioEntity.Context;
using RepositorioEntity.Models;
using Model.Geladeira;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            try
            {
                using (var transaction = _contexto.Database.BeginTransaction())
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
                        return "Container não encontrado.";

                    var posicaoExistente = _contexto.Posicaos.SingleOrDefault(posic => posic.PosicaoId == posicao);
                    if (posicaoExistente == null)
                        return "Posicao não encontrada.";

                    var novoItem = new Item
                    {
                        NomeItem = itemModel.Nome,
                        ContainerId = container,
                        PosicaoId = posicao
                    };

                    // Adiciona o item ao contexto
                    _contexto.Items.Add(novoItem);

                    // Salva as alterações no banco de dados
                    _contexto.SaveChanges();

                    // Confirma a transação
                    transaction.Commit();
                    return "Item adicionado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
        }

        public List<ItemModel> GetListaDeItem()
        {
            var listaItens_Entity = new List<Item>();

            try
            {
                listaItens_Entity = _contexto.Items.ToList();

                if (listaItens_Entity != null)
                {
                    var listaItens_Model = new List<ItemModel>();

                    foreach (var item in listaItens_Entity)
                    {
                        listaItens_Model.Add(
                            new ItemModel(id: item.ItemId, nome: item.NomeItem ?? string.Empty));
                    }

                    return listaItens_Model;
                }

                else
                    return null;
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
    }
}
