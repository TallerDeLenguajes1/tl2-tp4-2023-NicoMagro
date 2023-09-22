using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CadeteriaController : ControllerBase
    {
        private Cadeteria _cadeteria;
        private readonly ILogger<CadeteriaController> _logger;

        public CadeteriaController(ILogger<CadeteriaController> logger)
        {
            _logger = logger;
            _cadeteria = Cadeteria.Instance;
        }

        [HttpGet("nombre")]
        public IActionResult GetNombreCadeteria()
        {
            return Ok(_cadeteria.Nombre);
        }

        [HttpGet("pedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(_cadeteria.ListaPedidos);
        }

        [HttpGet("cadetes")]
        public IActionResult GetCadetes()
        {
            return Ok(_cadeteria.ListaCadetes);
        }

        [HttpGet("informe")]
        public IActionResult GetInforme()
        {
            return Ok(_cadeteria.CadInforme);
        }

    }
}