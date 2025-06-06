using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Repositories
{
    public class RevendaRepository : IRevendaRepository
    {
        private readonly List<Revenda> _ListRevendas = new List<Revenda>();

        public void Adicionar(Revenda revenda)
        {
            _ListRevendas.Add(revenda);
        }

        public IEnumerable<Revenda> ObterTodas()
        {
            return _ListRevendas;
        }
    }
}
