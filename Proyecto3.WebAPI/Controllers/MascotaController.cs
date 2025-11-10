using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto3.AccesoDatos.AccesoDB;
using Proyecto3.Entidades.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto3.WebAPI.Controllers
{
    [Route("api/Mascota")]
    [ApiController]
    public class MascotaController(DBContexto dBContexto) : ControllerBase
    {
        private readonly DBContexto _dbContexto = dBContexto;

        // GET: api/<MascotaController>/5
        [HttpGet("BuscarMascota/{criterioBusqueda}")]
        public ActionResult<IEnumerable<Mascota>> BuscarMascota(string criterioBusqueda)
        {
            try
            {
                var mascotas = _dbContexto.Mascotas
                    .Where(m => m.ClienteCedula!.Contains(criterioBusqueda) ||
                                m.Especie!.Contains(criterioBusqueda) ||
                                m.Raza!.Contains(criterioBusqueda) ||
                                m.Color!.Contains(criterioBusqueda) ||
                                m.NombreMascota!.Contains(criterioBusqueda))
                    .ToList();
                if (mascotas.Count == 0)
                {
                    return NotFound("No se encontraron mascotas que coincidan con el criterio de búsqueda");
                }
                return Ok(mascotas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        // GET: api/<MascotaController>
        [HttpGet("ListarMascotas")]
        public ActionResult<IEnumerable<Mascota>> ListarMascotas()
        {
            try
            {
                var mascotas = _dbContexto.Mascotas.ToList();
                return Ok(mascotas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST api/<MascotaController>
        [HttpPost("CrearMascota")]
        public ActionResult CrearMascota([FromBody] Mascota mascota)
        {
            try
            {
                _dbContexto.Mascotas.Add(mascota);
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

        // GET api/<MascotaController>/5
        [HttpGet("LeerMascota/{id}")]
        public ActionResult<Mascota> LeerMascota(int id)
        {
            try
            {
                var mascota = _dbContexto.Mascotas.FirstOrDefault(m => m.Id == id);
                if (mascota == null)
                {
                    return NotFound($"Mascota {id} no encontrada");
                }
                return Ok(mascota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<MascotaController>
        [HttpPut("ActualizarMascota")]
        public ActionResult ActualizarMascota([FromBody] Mascota mascotaActualizada)
        {
            try
            {
                var mascota = _dbContexto.Mascotas.FirstOrDefault(m => m.Id == mascotaActualizada.Id);

                if (mascota == null)
                {
                    return NotFound($"Mascota {mascotaActualizada.Id} no encontrada");
                }

                mascota.UltimaAtencion = mascotaActualizada.UltimaAtencion;
                mascota.ClienteCedula = mascotaActualizada.ClienteCedula;                
                mascota.NombreMascota = mascotaActualizada.NombreMascota;
                mascota.Especie = mascotaActualizada.Especie;
                mascota.Raza = mascotaActualizada.Raza;
                mascota.Edad = mascotaActualizada.Edad;

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

        // DELETE api/<MascotaController>/5
        [HttpDelete("EliminarMascota/{id}")]
        public ActionResult EliminarMascota(int id)
        {
            try
            {
                var mascota = _dbContexto.Mascotas.FirstOrDefault(m => m.Id == id);

                if (mascota == null)
                {
                    return NotFound($"Mascota {id} no encontrada");
                }

                EliminarProcedimientosDeMascota(mascota);
                EliminarMascota(mascota);

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
        /// <summary>
        /// Metodo para eliminar una mascota.
        /// </summary>
        /// <param name="mascota">Ojeto <Proyecto3.Entidades.Clases.Mascota> que se desea eliminar.</param>
        /// <returns>Positivo en caso de realizar todas las acciones necesarias.</returns>
        private bool EliminarMascota(Mascota mascota)
        {
            _dbContexto.Mascotas.Remove(mascota);

            _dbContexto.SaveChanges();

            return true;
        }
        /// <summary>
        /// Metodo para eliminar los procedimientos de una mascota.
        /// </summary>
        /// <param name="mascota">Ojeto <Proyecto3.Entidades.Clases.Mascota> asignada al Procedimiento </param>
        /// <returns>Positivo en caso de realizar todas las acciones necesarias.</returns>
        private bool EliminarProcedimientosDeMascota(Mascota mascota)
        {
            var procedimientos = from p in _dbContexto.Procedimientos
                                 join m in _dbContexto.Mascotas on p.Mascota!.Id equals m.Id
                                 where m.Id == mascota.Id
                                 select p;
            
            _dbContexto.Procedimientos.RemoveRange(procedimientos);
            _dbContexto.SaveChanges();
            
            return true;
        }
    }
}
