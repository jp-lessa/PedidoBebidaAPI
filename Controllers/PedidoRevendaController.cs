using Microsoft.AspNetCore.Mvc;
using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Services;

namespace PedidoBebidaAPI.Controllers
{
    [ApiController]
    [Route("api/pedidos-revenda")]
    public class PedidoRevendaController : Controller
    {
        private readonly PedidoRevendaService _pedidoService;

        public PedidoRevendaController(PedidoRevendaService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Envia pedido da revenda para a API externa.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> EnviarPedido([FromBody] PedidoRevendaRequest request)
        {
            try
            {
                var response = await _pedidoService.EnviarPedidoAsync(request);
                return Created(string.Empty, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
