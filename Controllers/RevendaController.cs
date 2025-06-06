using Microsoft.AspNetCore.Mvc;
using PedidoBebidaAPI.DTOs;
using PedidoBebidaAPI.Services;

namespace PedidoBebidaAPI.Controllers
{
    [ApiController]
    [Route("api/revenda")]
    public class RevendaController : ControllerBase
    {
        private readonly RevendaService _revendaService;

        public RevendaController(RevendaService revendaService)
        {
            _revendaService = revendaService;
        }

        /// <summary>
        /// Cadastra uma nova revenda.
        /// </summary>
        [HttpPost]
        public IActionResult CadastrarRevenda([FromBody] RevendaRequest request)
        {
            _revendaService.Cadastrar(request);
            return Created(string.Empty, new { message = "Revenda cadastrada com sucesso!" });
        }

        /// <summary>
        /// Lista todas as revendas cadastradas.
        /// </summary>
        [HttpGet]
        public IActionResult ListarRevendas()
        {
            var revendas = _revendaService.Listar();
            return Ok(revendas);
        }
    }
}
