namespace PedidoBebidaAPI.DTOs
{
    public class ItemPedidoRequest
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}
