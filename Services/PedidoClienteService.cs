using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Services
{
    public class PedidoClienteService
    {
        private static readonly List<PedidoCliente> _ListPedidos = new List<PedidoCliente>();
        private readonly ILogger<PedidoClienteService> _logger;

        public PedidoClienteService(ILogger<PedidoClienteService> logger)
        {
            _logger = logger;
        }

        public PedidoClienteResponse CriarPedido(PedidoClienteRequest request)
        {
            _logger.LogInformation("Iniciando criação de pedido do Cliente {ClienteId}", request.ClienteId);

            var pedido = new PedidoCliente
            {
                ClienteId = request.ClienteId,
                Itens = ObterItens(request.Itens)
            };

            _ListPedidos.Add(pedido);

            _logger.LogInformation("Pedido criado com sucesso. ID Pedido: {PedidoId}", pedido.Id);


            return new PedidoClienteResponse
            {
                PedidoId = pedido.Id,
                Itens = request.Itens
            };
        }

        private List<ItemPedido> ObterItens(List<ItemPedidoRequest>? itens)
        {
            if (itens == null || itens.Count == 0)
            {
                _logger.LogWarning("Pedido recebido sem itens. Cliente: {ClienteId}", itens);

                return new List<ItemPedido>();
            }
            return itens.Select(i => new ItemPedido
            {
                Produto = i.Produto,
                Quantidade = i.Quantidade
            }).ToList();
        }
    }
}
