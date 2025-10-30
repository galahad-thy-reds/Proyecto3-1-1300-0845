using Microsoft.AspNetCore.Mvc;
using Proyecto3.AccesoDatos.AccesoDB;
using Proyecto3.Entidades.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto3.WebAPI.Controllers
{
    [Route("api/TipoProcedimiento")]
    [ApiController]
    public class TipoProcedimientoController(DBContexto dBContexto) : ControllerBase
    {
        private readonly DBContexto _dbContexto = dBContexto;

        // GET: api/<TipoProcedimientoController>
        [HttpGet]
        public ActionResult<IEnumerable<TipoProcedimiento>> ListarTipoProcedimiento()
        {
            try
            {
                var tiposProcedimiento = _dbContexto.TiposProcedimiento.ToList();
                return Ok(tiposProcedimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
