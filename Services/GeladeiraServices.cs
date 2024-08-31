using RepositorioEntity.Context;

namespace Services
{
    public class GeladeiraService
    {
        private GeladeiraDbContext _contexto;

        public GeladeiraService(GeladeiraDbContext contexto)
        {
            _contexto = contexto;
        }
    }
}
