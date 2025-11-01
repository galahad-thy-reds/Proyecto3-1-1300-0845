using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Entidades.Clases
{
    /// <summary>
    /// Clase que representa un Procedimiento
    /// </summary>
    public class Procedimiento
    {
        #region Propiedades
        /// <summary>
        /// Identificador unico del procedimiento
        /// </summary>
        [DisplayName("Id del Procedimiento")]
        public int Id { get; set; }
        public string? ClienteCedula { get; set; }
        /// <summary>
        /// Cedula del contacto que solicita el procedimiento
        /// </summary>
        [DisplayName("Cliente")]
        public Cliente? Cliente { get; set; }
        public int MascotaId { get; set; }
        /// <summary>
        /// Nombre de la mascota a la que se le realizara el procedimiento
        /// </summary>
        [DisplayName("Mascota")]
        public Mascota? Mascota { get; set; }
        /// <summary>
        /// Identificador del tipo de procedimiento a realizar
        /// </summary>
        public int TipoProcedimientoId { get; set; }
        /// <summary>
        /// Tipo de consulta a realizar
        /// </summary>
        [DisplayName("Tipo Procedimiento")]
        public virtual TipoProcedimiento? TipoProcedimiento { get; set; }
        /// <summary>
        /// Estado del procedimiento (en proceso, facturado, agendado)
        /// </summary>
        [Required(ErrorMessage = "Por favor, seleccione un estado del procedimiento")]
        public string? Estado { get; set; }
        /// <summary>
        /// Fecha en la que se realizara el procedimiento
        /// </summary>
        [DataType(DataType.Date)]
        public DateOnly Fecha { get; set; }
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo para calcular el precio final del procedimiento con un impuesto del 13%
        /// </summary>
        /// <returns>PrecioFinal: Precio final del procedimiento con un impuesto del 13%</returns>
        public double PrecioFinal(double impuesto = 1.13)
        {
            if (TipoProcedimiento is not null)
            {
                return TipoProcedimiento.Precio * impuesto;
            }

            return 0;
        }
        #endregion
    }
}
