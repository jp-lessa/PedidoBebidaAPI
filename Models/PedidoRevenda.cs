namespace PedidoBebidaAPI.Models
{
    public class PedidoRevenda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CnpjRevenda { get; set; } = string.Empty;
        public List<ItemPedidoRevenda> Itens { get; set; }
    }
}
