using System.Text.Json;
using System.Text;
using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Repositories;
using PedidoBebidaAPI.Validators;
using PedidoBebidaAPI.Models;

namespace PedidoBebidaAPI.Services
{
    public class PedidoRevendaService
    {
        private readonly IPedidoExternoService _pedidoExternoService;
        private readonly PedidoRevendaValidator _validatorPedidoRevenda;

        public PedidoRevendaService(IPedidoExternoService pedidoExternoService, PedidoRevendaValidator validatorPedidoRevenda)
        {
            _pedidoExternoService = pedidoExternoService;
            _validatorPedidoRevenda = validatorPedidoRevenda;
        }

        public async Task<PedidoRevendaResponse> EnviarPedidoAsync(PedidoRevendaRequest request)
        {
            _validatorPedidoRevenda.Validar(request);

            var pedido = new PedidoRevenda
            {
                CnpjRevenda = request.CnpjRevenda,
                Itens = request.Itens.Select(i => new ItemPedidoRevenda
                {
                    Produto = i.Produto,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            var response = await _pedidoExternoService.EnviarPedidoAsync(pedido);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao enviar pedido para API externa: {(int)response.StatusCode} - {erro}");
            }

            return new PedidoRevendaResponse
            {
                PedidoId = pedido.Id,
                Itens = request.Itens
            };

        }
    }
}
