using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        public ICUListado<Articulo> CUListado { get; set; }
        public ICUListadoArticulosOrdenado CUListadoArticulosOrdenado { get; set; }

        public ArticulosController(ICUListadoArticulosOrdenado cuListadoArticulosOrdenado, ICUListado<Articulo> cuListado)
        {
            CUListadoArticulosOrdenado = cuListadoArticulosOrdenado;
            CUListado = cuListado;
        }

        // GET: api/<ArticulosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUListadoArticulosOrdenado.OrdenarAlfabeticamenteAsc(CUListado.ObtenerListado()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
