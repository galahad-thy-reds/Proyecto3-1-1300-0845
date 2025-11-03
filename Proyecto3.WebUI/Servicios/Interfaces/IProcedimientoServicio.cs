using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Interfaces
{
    public interface IProcedimientoServicio
    {
        /// <summary>
        /// Metodo para crear un procedimiento nuevo.
        /// </summary>
        /// <param name="procedimiento">Objeto <Proyecto2.Entidades.Clases.Procedimiento> con los datos del procedimiento</param>
        /// <returns>Verdadero en caso de crear el procedimiento. Falso, en caso contrario</returns>
        public Task<bool> CrearProcedimiento(Procedimiento procedimiento);
        /// <summary>
        /// Metodo para leer un procedimiento existente.
        /// </summary>
        /// <param name="id">Valor <string> con el identificador del procedimiento que se desea leer</param>
        /// <returns>Objeto Task<Proyecto2.Entidades.Clases.Procedimiento> del procedimiento</returns>
        public Task<Procedimiento> LeerProcedimiento(int id);
        /// <summary>
        /// Metodo para actualizar los datos de un procedimiento existente.
        /// </summary>
        /// <param name="procedimiento">Objeto <Proyecto2.Entidades.Clases.Procedimiento> con los datos actualizados del procedimiento.</param>
        /// <returns>Verdadero en caso de actualizar el procedimiento. Falso, en caso contrario</returns>
        public Task<bool> ActualizarProcedimiento(Procedimiento procedimiento);
        /// <summary>
        /// Metodo para eliminar un procedimiento existente.
        /// </summary>
        /// <param name="id">Valor <string> con el identificador del procedimiento que se desea eliminar</param>
        /// <returns>Verdadero en caso de eliminar el procedimiento. Falso, en caso contrario</returns>
        public Task<bool> EliminarProcedimiento(int id);
        /// <summary>
        /// Metodo para buscar procedimientos por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda">Valor <string> con el criterio de busqueda.</param>
        /// <returns>Objeto Task<IEnumerable<Proyecto2.Entidades.Clases.Procedimiento>>.</returns>
        public Task<IEnumerable<Procedimiento>> BuscarProcedimiento(string criterioBusqueda);
        /// <summary>
        /// Metodo para listar todos los procedimientos existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Procedimiento>> </returns>
        public Task<IEnumerable<Procedimiento>> ListarProcedimientos();
    }
}
