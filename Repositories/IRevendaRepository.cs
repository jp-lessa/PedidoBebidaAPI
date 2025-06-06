using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Repositories
{
    public interface IRevendaRepository
    {
        void Adicionar(Revenda revenda);
        IEnumerable<Revenda> ObterTodas();
    }
}
