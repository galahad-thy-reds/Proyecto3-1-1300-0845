using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Entidades.Clases
{
    /// <summary>
    /// Clase que representa un Tipo de Procedimiento
    /// </summary>
    public class TipoProcedimiento
    {
        #region Propiedades
        /// <summary>
        /// Identificador unico del tipo de procedimiento
        /// </summary>
        [DisplayName("Tipo Procedimiento")]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del tipo del procedimiento (consulta general, vacunacion, desparasitacion, cirugia, emergencia, otro)
        /// </summary>
        [DisplayName("Tipo Procedimiento")]
        public string? Nombre { get; set; }
        /// <summary>
        /// Descripcion del tipo de procedimiento
        /// </summary>
        [DisplayName("Descripcion del Procedimiento")]
        public string? Descripcion { get; set; }
        /// <summary>
        /// Precio del tipo de procedimiento
        /// </summary>
        [DisplayName("Precio del procedimiento (sin IVA)")]
        public double Precio { get; set; }
        #endregion
    }
}
