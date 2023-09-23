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

        [HttpPost("agregarPedido")]
        public IActionResult AgregarPedido()
        {
            int cantPedidos = _cadeteria.ListaPedidos.Count;
            _cadeteria.AgregarPedido();
            if (_cadeteria.ListaPedidos.Count == cantPedidos + 1)
            {
                return Ok("Pedido agregado correctamente");
            }
            else
            {
                return StatusCode(500, "Ha ocurrido un error agregando el pedido.");
            }
        }


        [HttpPut("asignarPedido")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            _cadeteria.AsignarPedido(idPedido, idCadete);
            return Ok($"Pedido {idPedido} asignado al cadete {idCadete}.");
        }

        [HttpPut("cambiarEstadoPedido")]
        public IActionResult CambiarEstadoPedido(int idPedido, int nuevoEstado)
        {
            _cadeteria.CambiarEstadoPedido(idPedido, nuevoEstado);
            return Ok($"Estado del pedido {idPedido} cambiado a {nuevoEstado}.");
        }

        [HttpPut("cambiarCadetePedido")]
        public ActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            _cadeteria.CambiarCadetePedido(idPedido, idNuevoCadete);
            return Ok($"Cadete del pedido {idPedido} cambiado a {idNuevoCadete}.");
        }
    }
}