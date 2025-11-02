using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Interfaces
{
    public interface IEmpleadoServicio
    {
        /// <summary>
        /// Metodo para crear un Empleado nuevo.
        /// </summary>
        /// <param name="empleado">Objeto <Proyecto2.Entidades.Clases.Empleado> con los datos del empleado</param>
        /// <returns>Verdadero si se crea el empleado. Falso en caso contrario</returns>
        public Task<bool> CrearEmpleado(Empleado empleado);
        /// <summary>
        /// Metodo para leer un Empleado existente.
        /// </summary>
        /// <param name="cedula">Valor <string> con la cedula del empleado que se desea leer los datos</param>
        /// <returns>Objeto Task<Proyecto2.Entidades.Clases.Empleado> del empleado.</returns>
        public Task<Empleado> LeerEmpleado(string cedula);
        /// <summary>
        /// Metodo para actualizar los datos de un Empleado existente.
        /// </summary>
        /// <param name="empleado">Objeto <Proyecto2.Entidades.Clases.Empleado> con los datos actualizado del empleado</param>
        /// <returns>Verdadero si se actualiza el empleado. Falso en caso contrario</returns>d
        public Task<bool> ActualizarEmpleado(Empleado empleado);
        /// <summary>
        /// Metodo para eliminar un Empleado existente.
        /// </summary>
        /// <param name="empleado">Valor <string> con el empleado a eliminar</param>
        /// <returns>Verdadero si se elimina el empleado. Falso en caso contrario</returns>
        public Task<bool> EliminarEmpleado(string cedula);
        /// <summary>
        /// Metodo para buscar empleados por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda"></param>
        /// <returns>Objeto Task<IEnumerable<Proyecto2.Entidades.Clases.Empleado>> con la lista de empleados que cumplieron con el criterio de busqueda. Puede ser vacia.</returns>
        public Task<IEnumerable<Empleado>> BuscarEmpleado(string criterioBusqueda);
        /// <summary>
        /// Metodo para listar todos los empleados existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Proyecto2.Entidades.Clases.Empleado>> con la lista de empleados.</returns>
        public Task<IEnumerable<Empleado>> ListarEmpleados();
    }
}
