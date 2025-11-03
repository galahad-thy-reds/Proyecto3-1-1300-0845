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

        // GET api/<TipoProcedimientoController>/5
        [HttpGet("LeerTipoProcedimiento/{id}")]
        public ActionResult<TipoProcedimiento> LeerTipoProcedimiento(int id)
        {
            try
            {
                var tipoProcedimiento = _dbContexto.TiposProcedimiento.FirstOrDefault(tp => tp.Id == id);
                if (tipoProcedimiento == null)
                {
                    return NotFound($"Tipo de procedimiento con ID {id} no encontrado.");
                }
                return Ok(tipoProcedimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/<TipoProcedimientoController>
        [HttpGet("ListarTiposProcedimiento")]
        public ActionResult<IEnumerable<TipoProcedimiento>> ListarTiposProcedimiento()
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
