﻿using Model.Geladeira;
using RepositorioEntity.Models;

namespace RepositorioEntity.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        string AddNovoItem(int containerId, int posicaoId, ItemModel itemModel);

        List<Item> GetListarItens();

        Item GetItemById(int itemId);

        string DeletarItem(int itemId);

        string AtualizarNomeItem(TEntity entity);

        string EsvaziarContainer(int containerId);
    }
}
