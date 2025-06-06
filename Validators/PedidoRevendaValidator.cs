using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Repositories;

namespace PedidoBebidaAPI.Validators
{
    public class PedidoRevendaValidator
    {
        private readonly IRevendaRepository _revendaRepository;

        public PedidoRevendaValidator(IRevendaRepository revenda)
        {
            _revendaRepository = revenda;
        }

        public void Validar(PedidoRevendaRequest revendaRequest)
        {
            if (!_revendaRepository.ObterTodas().Any(r => r.Cnpj == revendaRequest.CnpjRevenda))
                throw new Exception("Revenda não cadastrada!");

            var totalItens = revendaRequest.Itens.Sum(q => q.Quantidade);
            if (totalItens < 1000)
                throw new Exception("Pedido ter no mínimo 1000 itens!");
        }

    }
}
