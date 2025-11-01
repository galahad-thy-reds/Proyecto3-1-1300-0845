using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto3.AccesoDatos.AccesoDB;
using Proyecto3.Entidades.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto3.WebAPI.Controllers
{
    [Route("api/Procedimiento")]
    [ApiController]
    public class ProcedimientoController(DBContexto dBContexto) : ControllerBase
    {
        private readonly DBContexto _dbContexto = dBContexto;

        // Get api/<ProcedimientoController>/5
        [HttpGet("BuscarProcedimiento/{criterioBusqueda}")]
        public ActionResult<IEnumerable<Procedimiento>> BuscarProcedimiento(string criterioBusqueda)
        {
            try
            {
                var procedimientos = _dbContexto.Procedimientos
                    .Include(p => p.Cliente)
                    .Include(p => p.Mascota)
                    .Include(p => p.TipoProcedimiento)
                    .Where(p => p.Cliente!.Cedula!.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase) ||
                                p.Mascota!.NombreMascota!.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase) ||
                                p.TipoProcedimiento!.Nombre!.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase) ||
                                p.Estado!.Contains(criterioBusqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return Ok(procedimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/<ProcedimientoController>
        [HttpGet("ListarProcedimientos")]
        public ActionResult<IEnumerable<Procedimiento>> ListarProcedimientos()
        {
            try
            {
                var procedimientos = _dbContexto.Procedimientos
                    .Include(p => p.Cliente)
                    .Include(p => p.Mascota)
                    .Include(p => p.TipoProcedimiento)
                    .ToList();

                return Ok(procedimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST api/<ProcedimientoController>
        [HttpPost("CrearProcedimiento")]
        public ActionResult CrearProcedimiento([FromBody] Procedimiento procedimiento)
        {
            try
            {
                _dbContexto.Procedimientos.Add(procedimiento);
                _dbContexto.SaveChanges();
                return Created();
            }
            catch (DbUpdateException ex)
            {
                return Conflict($"Error al actualizar la base de datos: {ex.InnerException!.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET api/<ProcedimientoController>/5
        [HttpGet("LeerProcedimiento/{id}")]
        public ActionResult<Procedimiento> LeerProcedimiento(int id)
        {
            try
            {
                var procedimiento = _dbContexto.Procedimientos
                    .Include(p => p.Cliente)
                    .Include(p => p.Mascota)
                    .Include(p => p.TipoProcedimiento)
                    .FirstOrDefault(p => p.Id == id);
                if (procedimiento == null)
                {
                    return NotFound($"Procedimiento {id} no encontrado");
                }
                return Ok(procedimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<ProcedimientoController>/
        [HttpPut("ActualizarProcedimiento/")]
        public ActionResult ActualizarProcedimiento([FromBody] Procedimiento procedimientoActualizado)
        {
            try
            {
                var procedimiento = _dbContexto.Procedimientos.FirstOrDefault(p => p.Id == procedimientoActualizado.Id);
                
                if (procedimiento == null)
                {
                    return NotFound($"Procedimiento {procedimientoActualizado.Id} no encontrado");
                }

                procedimiento.TipoProcedimientoId = procedimientoActualizado.TipoProcedimientoId;
                //procedimiento.TipoProcedimiento = procedimientoActualizado.TipoProcedimiento;
                procedimiento.ClienteCedula = procedimientoActualizado.ClienteCedula;
                //procedimiento.Cliente = procedimientoActualizado.Cliente;
                procedimiento.MascotaId = procedimientoActualizado.MascotaId;
                //procedimiento.Mascota = procedimientoActualizado.Mascota;
                procedimiento.Estado = procedimientoActualizado.Estado;
                procedimiento.Fecha = procedimientoActualizado.Fecha;
                
                _dbContexto.SaveChanges();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return Conflict($"Error al actualizar la base de datos: {ex.InnerException!.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // DELETE api/<ProcedimientoController>/5
        [HttpDelete("EliminarProcedimiento/")]
        public ActionResult EliminarProcedimiento([FromBody] Procedimiento procedimientoAEliminar)
        {
            try
            {
                var procedimiento = _dbContexto.Procedimientos.FirstOrDefault(p => p.Id == procedimientoAEliminar.Id);
                
                if (procedimiento == null)
                {
                    return NotFound($"Procedimiento {procedimientoAEliminar.Id} no encontrado");
                }

                _dbContexto.Procedimientos.Remove(procedimiento);
                
                _dbContexto.SaveChanges();
                
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return Conflict($"Error al actualizar la base de datos: {ex.InnerException!.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
