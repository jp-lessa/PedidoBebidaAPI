namespace PedidoBebidaAPI.DTOs
{
    public class PedidoRevendaResponse
    {
        public Guid PedidoId { get; set; }
        public List<ItemPedidoRevendaRequest> Itens { get; set; }
    }
}
