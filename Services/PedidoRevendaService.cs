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
        private readonly ILogger<PedidoRevendaService> _logger;


        public PedidoRevendaService(IPedidoExternoService pedidoExternoService, PedidoRevendaValidator validatorPedidoRevenda,
            ILogger<PedidoRevendaService> logger)
        {
            _pedidoExternoService = pedidoExternoService;
            _validatorPedidoRevenda = validatorPedidoRevenda;
            _logger = logger;
        }

        public async Task<PedidoRevendaResponse> EnviarPedidoAsync(PedidoRevendaRequest request)
        {
            _logger.LogInformation("Iniciando validação do pedido para a revenda de CNPJ {Cnpj}.", request.CnpjRevenda);
            _validatorPedidoRevenda.Validar(request);
            _logger.LogInformation("Pedido validado com sucesso. Preparando estrutura do pedido...");

            var pedido = new PedidoRevenda
            {
                CnpjRevenda = request.CnpjRevenda,
                Itens = request.Itens.Select(i => new ItemPedidoRevenda
                {
                    Produto = i.Produto,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            _logger.LogInformation("Enviando pedido para o serviço externo...");

            HttpResponseMessage response;

            try
            {
                response = await _pedidoExternoService.EnviarPedidoAsync(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar enviar o pedido para a API externa.");
                throw;
            }

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();
                _logger.LogError("Falha ao enviar pedido para API Externa: StatusCode {StatusCode} - {Erro}", (int)response.StatusCode, erro);
                throw new Exception($"Erro ao enviar pedido para API externa: {(int)response.StatusCode} - {erro}");
            }

            _logger.LogInformation("Pedido enviado com sucesso!");
            return new PedidoRevendaResponse
            {
                PedidoId = pedido.Id,
                Itens = request.Itens
            };

        }
    }
}
