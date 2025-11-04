using Proyecto3.Entidades.Clases;

namespace Proyecto3.WebUI.Servicios.Interfaces
{
    public interface IReporteServicio
    {
        /// <summary>
        /// Metodo para generar el reporte de procedimientos para vacunacion anual de la mascota de un cliente.
        /// </summary>
        /// <param name="id">Valor <int> con el identificador de la mascota.</param>
        /// <returns>Task<IEnumerable<Servicios.Cliente>>  con los valores de los clientes</returns>
        //public Task<IEnumerable<Cliente>> GenerarReporteProcedimientosParaVacunacionAnual(int id);
        public Task<IEnumerable<Cliente>> GenerarReporteProcedimientosParaVacunacionAnual();
    }
}
