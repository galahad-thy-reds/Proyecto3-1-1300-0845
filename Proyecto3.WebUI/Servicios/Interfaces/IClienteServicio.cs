using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Interfaces
{
    public interface IClienteServicio
    {
        /// <summary>
        /// Metodo para crear un cliente nuevo.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto2.Entidades.Clases.Cliente> con los datos del cliente</param>
        /// <returns>Verdadero si se agrega el cliente. Falso en caso contrario</returns>
        public Task<bool> CrearCliente(Cliente cliente);
        /// <summary>
        /// Metodo para leer un cliente existente.
        /// </summary>
        /// <param name="cedula">Valor <string> con la cedula del cliente que se desea leer los datos</param>
        /// <returns></returns>
        public Task<Cliente> LeerCliente(string cedula);
        /// <summary>
        /// Metodo para actualizar los datos de un cliente existente.
        /// </summary>
        /// <param name="cliente">Objeto <Proyecto2.Entidades.Clases.Cliente> con los datos actualizado del cliente</param>
        /// <returns>Verdadero si se actualiza el cliente. Falso en caso contrario</returns>
        public Task<bool> ActualizarCliente(Cliente cliente);
        /// <summary>
        /// Metodo para eliminar un cliente existente.
        /// </summary>
        /// <param name="Cliente">Valor <string> con el cliente a eliminar</param>
        /// <returns>Verdadero si se elimina el cliente. Falso en caso contrario</returns>
        public Task<bool> EliminarCliente(string cedula);
        /// <summary>
        /// Metodo para buscar clientes por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda"></param>
        /// <returns>Objeto Task<IEnumerable<cliente>> con la lista de Clientes que cumplieron con el criterio de busqueda. Puede ser vacia.</returns>
        public Task<IEnumerable<Cliente>> BuscarCliente(string criterioBusqueda);
        /// <summary>
        /// Metodo para listar todos los clientes existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Cliente>> con la lista de Clientes.</returns>
        public Task<IEnumerable<Cliente>> ListarClientes();
    }
}
