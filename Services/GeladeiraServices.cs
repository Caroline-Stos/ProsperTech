using Microsoft.Extensions.Configuration;
using RepositorioEntity.Context;
using RepositorioEntity.Models;
using Model.Geladeira;
using RepositorioEntity.Interfaces;
using Servicos.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Servicos
{
    public class GeladeiraService : IService<ItemModel>
    {
        IRepository<ItemModel> _repository;
        public GeladeiraService(IRepository<ItemModel> repository) =>
            _repository = repository;

        public string AddNovoItem(int containerId, int posicaoId, ItemModel itemModel) =>
            _repository.AddNovoItem(containerId, posicaoId, itemModel);

        public List<Item> GetListarItens() =>
            _repository.GetListarItens();

        public Item GetItemById(int itemId) =>
            _repository.GetItemById(itemId);

        public string DeletarItem(int itemId) =>
            _repository.DeletarItem(itemId);

        public string AtualizarNomeItem(ItemModel item) =>
            _repository.AtualizarNomeItem(item);

        public string EsvaziarContainer(int containerId) =>
            _repository.EsvaziarContainer(containerId);

    }
}