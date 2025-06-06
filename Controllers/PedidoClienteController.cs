using Microsoft.AspNetCore.Mvc;
using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Services;

namespace PedidoBebidaAPI.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoClienteController : ControllerBase
    {
        private readonly PedidoClienteService _pedidoService;

        public PedidoClienteController(PedidoClienteService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Cria pedido do cliente.
        /// </summary>
        [HttpPost]
        public IActionResult CriarPedido([FromBody] PedidoClienteRequest request )
        {
            var response = _pedidoService.CriarPedido(request);
            return Created(string.Empty, response);
        }
    }
}
