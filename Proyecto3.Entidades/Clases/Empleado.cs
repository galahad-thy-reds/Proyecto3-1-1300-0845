using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto3.Entidades.Clases
{
    /// <summary>
    /// Clase que representa un Empleado
    /// </summary>
    public class Empleado
    {
        #region Propiedades
        /// <summary>
        /// Cedula del Empleado
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Por favor, digite la cedula del empleado")]
        public string? Cedula { get; set; }
        /// <summary>
        /// Fecha de nacimiento del Empleado
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Fecha Nacimiento")]
        [Required(ErrorMessage = "Por favor, digite la fecha de nacimiento")]
        public DateOnly FechaNacimiento { get; set; }
        /// <summary>
        /// Fecha de ingreso a la empresa del Empleado
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "Por favor, digite la fecha de ingreso")]
        public DateOnly FechaIngreso { get; set; }
        /// <summary>
        /// Salario por dia del Empleado
        /// </summary>
        [DisplayName("Salario por Dia")]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Por favor, el salario por dia")]
        public decimal SalarioDiario { get; set; }
        /// <summary>
        /// Fecha de retiro del Empleado, si no se ha retirado es null
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Retiro")]
        public DateOnly? FechaRetiro { get; set; }
        /// <summary>
        /// Tipo de contrato del Empleado, ejemplos: veterinario, asistente, administrativo, mantenimiento, groomer.
        /// </summary>
        [DisplayName("Tipo de Empleado")]
        [Required(ErrorMessage = "Por favor, seleccione un tipo de empleado")]
        public string? TipoEmpleado { get; set; }
        #endregion
    }
}
