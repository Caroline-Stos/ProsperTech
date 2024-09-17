
using Model.Geladeira;
using RepositorioEntity.Models;

namespace Servicos.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        string AddNovoItem(int containerId, int posicaoId, ItemModel itemModel);

        List<Item> GetListarItens();

        Item GetItemById(int itemId);

        string DeletarItem(int itemId);

        string AtualizarNomeItem(TEntity entity);

        string EsvaziarContainer(int containerId);
    }
}

