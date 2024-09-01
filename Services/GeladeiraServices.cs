using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositorioEntity.Context;
using RepositorioEntity.Models;
using Model.Geladeira;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;

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

                    // Adiciona o item ao contexto
                    _contexto.Items.Add(novoItem);

                    // Salva as alterações no banco de dados
                    _contexto.SaveChanges();

                    // Confirma a transação
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

        public string DeleteItem(int itemId)
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
                    return "Erro ao excluir item.";
                }
            }
            
        }
    }
}
