using System.Text.Json;
using System.Text;
using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Services
{
    public class PedidoExternoService : IPedidoExternoService
    {
        private readonly HttpClient _client;

        public PedidoExternoService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:5001");
        }


        public async Task<HttpResponseMessage> EnviarPedidoAsync(PedidoRevenda pedido)
        {
            var json = JsonSerializer.Serialize(pedido);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return await _client.PostAsync("/api/integracoes/pedidos", content);
        }
    }
}
