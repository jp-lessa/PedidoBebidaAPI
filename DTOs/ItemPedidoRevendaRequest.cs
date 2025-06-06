namespace PedidoBebidaAPI.DTOs
{
    public class ItemPedidoRevendaRequest
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}
