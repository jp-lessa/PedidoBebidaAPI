using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Services
{
    public interface IPedidoExternoService
    {
        Task<HttpResponseMessage> EnviarPedidoAsync(PedidoRevenda pedido);

    }
}
