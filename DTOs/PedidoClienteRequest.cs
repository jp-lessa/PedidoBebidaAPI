namespace PedidoBebidaAPI.DTOs
{
    public class PedidoClienteRequest
    {
        public string ClienteId { get; set; } = string.Empty;
        public List<ItemPedidoRequest>? Itens { get; set; }
    }
}
