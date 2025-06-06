namespace PedidoBebidaAPI.DTOs
{
    public class PedidoClienteResponse
    {
        public Guid PedidoId { get; set; }
        public List<ItemPedidoRequest>? Itens { get; set; }
    }
}
