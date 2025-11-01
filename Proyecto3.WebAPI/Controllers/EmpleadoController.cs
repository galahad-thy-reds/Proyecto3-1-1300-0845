using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto3.AccesoDatos.AccesoDB;
using Proyecto3.Entidades.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto3.WebAPI.Controllers
{
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController(DBContexto dBContexto) : ControllerBase
    {
        private readonly DBContexto _dbContexto = dBContexto;

        // GET api/<EmpleadoController>/5
        [HttpGet("BuscarEmpleado/{criterioBusqueda}")]
        public ActionResult<IEnumerable<Empleado>> BuscarEmpleado(string criterioBusqueda)
        {
            try
            {
                var empleados = _dbContexto.Empleados
                    .Where(e => e.Cedula!.Contains(criterioBusqueda) ||
                                e.TipoEmpleado!.Contains(criterioBusqueda))
                    .ToList();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/<EmpleadoController>
        [HttpGet("ListarEmpleados")]
        public ActionResult<IEnumerable<Empleado>> ListarEmpleados()
        {
            try
            {
                var empleados = _dbContexto.Empleados.ToList();

                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        
        // POST api/<EmpleadoController>
        [HttpPost("CrearEmpleado")]
        public ActionResult CrearEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                _dbContexto.Empleados.Add(empleado);

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
        
        // GET api/<EmpleadoController>/5
        [HttpGet("LeerEmpleado/{cedula}")]
        public ActionResult<Empleado> LeerEmpleado(string cedula)
        {
            try
            {
                var empleado = _dbContexto.Empleados.FirstOrDefault(e => e.Cedula == cedula);

                if (empleado == null)
                {
                    return NotFound($"Empleado {cedula} no encontrado");
                }

                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        
        // PUT api/<EmpleadoController>/
        [HttpPut("ActualizarEmpleado")]
        public ActionResult<Empleado> ActualizarEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                var empleadoExistente = _dbContexto.Empleados.FirstOrDefault(e => e.Cedula == empleado.Cedula);
                
                if (empleadoExistente == null)
                {
                    return NotFound("Empleado no encontrado");
                }

                empleadoExistente.Cedula = empleado.Cedula;
                empleadoExistente.FechaNacimiento = empleado.FechaNacimiento;
                empleadoExistente.FechaIngreso = empleado.FechaIngreso;
                empleadoExistente.SalarioDiario = empleado.SalarioDiario;
                empleadoExistente.FechaRetiro = empleado.FechaRetiro;
                empleadoExistente.TipoEmpleado = empleado.TipoEmpleado;
                _dbContexto.SaveChanges();

                return Ok(empleadoExistente);
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
        
        // DELETE api/<EmpleadoController>/5
        [HttpDelete("EliminarEmpleado/{cedula}")]
        public ActionResult EliminarEmpleado(string cedula)
        {
            try
            {
                var empleado = _dbContexto.Empleados.FirstOrDefault(e => e.Cedula == cedula);

                if (empleado == null)
                {
                    return NotFound("Empleado no encontrado");
                }

                _dbContexto.Empleados.Remove(empleado);
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
