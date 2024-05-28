using LogicaAplicacion.CasosUso.CUPedidos;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        public ICUListadoPedidosAnulados CUListadoPedidosAnulados { get; set; }

        public PedidosController(ICUListadoPedidosAnulados cuListadoPedidosAnulados)
        {
            CUListadoPedidosAnulados = cuListadoPedidosAnulados;
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUListadoPedidosAnulados.ObtenerListadoPedidosAnuladosYNoAnulados(true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
