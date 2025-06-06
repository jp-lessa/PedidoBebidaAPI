namespace PedidoBebidaAPI.Models
{
    public class PedidoCliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ClienteId { get; set; } = string.Empty;
        public List<ItemPedido>? Itens { get; set; }
    }
}
