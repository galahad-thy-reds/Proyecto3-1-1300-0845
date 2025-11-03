using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Interfaces
{
    public interface IMascotaServicio
    {
        /// <summary>
        /// Metodo para crear una Mascota nueva.
        /// </summary>
        /// <param name="mascota">Objeto <Proyecto2.Entidades.Clases.Mascota> con los datos del Mascota</param>
        /// <returns>Verdadero si se crea la mascota. Falso en caso contrario</returns>
        public Task<bool> CrearMascota(Mascota mascota);
        /// <summary>
        /// Metodo para leer una Mascota existente.
        /// </summary>
        /// <param name="id">Valor <int> con el identificador de la mascota</param>
        /// <returns>Objeto Task<Proyecto2.Entidades.Clases.Mascota> de la mascota</returns>
        public Task<Mascota> LeerMascota(int id);
        /// <summary>
        /// Metodo para actualizar los datos de una Mascota existente.
        /// </summary>
        /// <param name="Mascota">Objeto <Proyecto2.Entidades.Clases.Mascota> con los datos actualizado del Mascota</param>
        /// <returns>Verdadero si se actualiza la mascota. Falso en caso contrario</returns>
        public Task<bool> ActualizarMascota(Mascota Mascota);
        /// <summary>
        /// Metodo para eliminar una Mascota existente.
        /// </summary>
        /// <param name="id">Valor <int> con el identificador de la mascota</param>
        /// <returns>Verdadero si se crea la mascota. Falso en caso contrario</returns>
        public Task<bool> EliminarMascota(int id);
        /// <summary>
        /// Metodo para buscar Mascotas por criterio de busqueda.
        /// </summary>
        /// <param name="criterioBusqueda"></param>
        /// <returns>Objeto Task<IEnumerable<Mascota>> con la lista de Mascotas que cumplieron con el criterio de busqueda. Puede ser vacia.</returns>
        public Task<IEnumerable<Mascota>> BuscarMascota(string criterioBusqueda);
        /// <summary>
        /// Metodo para listar todos las Mascotas existentes.
        /// </summary>
        /// <returns>Objeto Task<IEnumerable<Mascota>> con la lista de Mascotas.</returns>
        public Task<IEnumerable<Mascota>> ListarMascotas();
    }
}
