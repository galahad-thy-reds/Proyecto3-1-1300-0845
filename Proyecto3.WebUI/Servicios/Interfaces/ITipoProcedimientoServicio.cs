using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Interfaces
{
    public interface ITipoProcedimientoServicio
    {
        /// <summary>
        /// Metodo ara leer un tipo de procedimiento por su id.
        /// </summary>
        /// <param name="id">Identificador del tipo de procedimiento</param>
        /// <returns></returns>
        public Task<TipoProcedimiento> LeerProcedimiento(int id);
        /// <summary>
        /// Procedimiento para listar todos los tipos de procedimientos.
        /// </summary>
        /// <returns>Objeto IEnumerable<Proyecto2.Entidades.ClasesTipoProcedimiento> con todos los tipos de procedimientos.</returns>
        public Task<IEnumerable<TipoProcedimiento>> Listar();
    }
}
