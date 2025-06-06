namespace PedidoBebidaAPI.DTOs
{
    public class PedidoRevendaRequest
    {
        public string CnpjRevenda { get; set; } = string.Empty;
        public List<ItemPedidoRevendaRequest>? Itens { get; set; }
    }
}
