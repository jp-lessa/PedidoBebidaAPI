using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Services
{
    public class PedidoClienteService
    {
        private static readonly List<PedidoCliente> _ListPedidos = new List<PedidoCliente>();

        public PedidoClienteResponse CriarPedido(PedidoClienteRequest request)
        {
            var pedido = new PedidoCliente
            {
                ClienteId = request.ClienteId,
                Itens = ObterItens(request.Itens)
            };

            _ListPedidos.Add(pedido);

            return new PedidoClienteResponse
            {
                PedidoId = pedido.Id,
                Itens = request.Itens
            };
        }

        private List<ItemPedido> ObterItens(List<ItemPedidoRequest>? itens)
        {
            if (itens == null || itens.Count == 0)
                return new List<ItemPedido>();

            return itens.Select(i => new ItemPedido
            {
                Produto = i.Produto,
                Quantidade = i.Quantidade
            }).ToList();
        }   
    }
}
