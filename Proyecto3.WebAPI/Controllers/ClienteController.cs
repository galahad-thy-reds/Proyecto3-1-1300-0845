using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto3.AccesoDatos.AccesoDB;
using Proyecto3.Entidades.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto3.WebAPI.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController(DBContexto dBContexto) : ControllerBase
    {
        private readonly DBContexto _dbContexto = dBContexto;

        // GET: api/<ClienteController>
        [HttpGet("ListarClientes")]
        public ActionResult<IEnumerable<Cliente>> ListarClientes()
        {
            try
            {
                var clientes = _dbContexto.Clientes.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        
        // POST api/<ClienteController>
        [HttpPost("CrearCliente")]
        public ActionResult CrearCliente([FromBody] Cliente cliente)
        {
            try
            {
                _dbContexto.Clientes.Add(cliente);

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
        
        // GET api/<ClienteController>/5
        [HttpGet("LeerCliente/{cedula}")]
        public ActionResult<Cliente> LeerCliente(string cedula)
        {
            try
            {
                var cliente = _dbContexto.Clientes
                    .Include(static c => c.Mascotas)
                    .FirstOrDefault(c => c.Cedula == cedula);
                if (cliente == null)
                {
                    return NotFound($"Cliente {cedula} no encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("ActualizarCliente/{cedula}")]
        public ActionResult ActualizarCliente(string cedula, [FromBody] Entidades.Clases.Cliente clienteActualizado)
        {
            try
            {
                var cliente = _dbContexto.Clientes.FirstOrDefault(c => c.Cedula == cedula);
                if (cliente == null)
                {
                    return NotFound($"Cliente {cedula} no encontrado");
                }
                cliente.Nombre = clienteActualizado.Nombre;
                cliente.Direccion = clienteActualizado.Direccion;
                cliente.Telefono = clienteActualizado.Telefono;
                // Actualizar otros campos según sea necesario
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

        // DELETE api/<ClienteController>/5
        [HttpDelete("EliminarCliente/{cedula}")]
        public ActionResult EliminarCliente(string cedula)
        {
            try
            {
                var cliente = _dbContexto.Clientes.FirstOrDefault(c => c.Cedula == cedula);

                if (cliente == null)
                {
                    return NotFound($"Cliente {cedula} no encontrado");
                }

                EliminarProcedimientosDelCliente(cliente);
                EliminarMascotasDelCliente(cliente);
                EliminarCliente(cliente);

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
        /// Metodo para eliminar un cliente.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto3.Entidades.Clases.Cliente> para eliminar.</param>
        private void EliminarCliente(Cliente cliente)
        {
            _dbContexto.Clientes.Remove(cliente);

            _dbContexto.SaveChanges();
        }
        /// <summary>
        /// Metodo para eliminar las mascotas de un cliente.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto3.Entidades.Clases.Cliente>.</param>
        private void EliminarMascotasDelCliente(Cliente cliente)
        {
            var mascotas = _dbContexto.Mascotas.Where(m => m.ClienteCedula == cliente.Cedula).ToList();

            _dbContexto.Mascotas.RemoveRange(mascotas);
            _dbContexto.SaveChanges();
        }
        /// <summary>
        /// Metodo para eliminar los procedimientos de un cliente.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto3.Entidades.Clases.Cliente>.</param>
        private void EliminarProcedimientosDelCliente(Cliente cliente)
        {
            var procedimientos = from p in _dbContexto.Procedimientos
                                 join c in _dbContexto.Clientes on p.Cliente!.Cedula equals c.Cedula
                                 where c.Cedula == cliente.Cedula
                                 select p;

            _dbContexto.Procedimientos.RemoveRange(procedimientos);

            _dbContexto.SaveChanges();
        }
    }
}
