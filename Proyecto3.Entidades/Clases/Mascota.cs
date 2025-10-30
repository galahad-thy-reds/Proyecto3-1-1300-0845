using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Entidades.Clases
{
    /// <summary>
    /// Clase que representa una Mascota
    /// </summary>
    public class Mascota
    {
        #region Propiedades
        /// <summary>
        /// Identificador unico de la mascota
        /// </summary>
        [Key]
        public int Id { get; set; } = System.Random.Shared.Next(1, 1000000);
        /// <summary>
        /// Cedula del cliente o dueño de la mascota
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite la cedula del cliente")]
        [DisplayName("Cedula del Cliente")]
        public virtual string? CedulaCliente { get; set; }
        /// <summary>
        /// Nombre de la mascota
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite el nombre de la mascota")]
        [DisplayName("Nombre de la Mascota")]
        public string? NombreMascota { get; set; }
        /// <summary>
        /// Especie de la mascota (caballo, perro, gato, pez, cabra, conejo, vaca, cerdo, roedor, serpiente, otro.)
        /// </summary>
        [Required(ErrorMessage = "Por favor, seleccione una especie")]
        public string? Especie { get; set; }
        /// <summary>
        /// Raza de la mascota (si es perro: pastor aleman, labrador, bulldog, etc. Si es gato: siamés, persa, etc.)
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite una raza")]
        public string? Raza { get; set; }
        /// <summary>
        /// Edad de la mascota en años (puede ser decimal, por ejemplo: 2.5)
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique la edad de la mascota")]
        public decimal Edad { get; set; }
        /// <summary>
        /// Color de la mascota
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique el color de la mascota")]
        public string? Color { get; set; }
        /// <summary>
        /// Fecha de la ultima atencion de la mascota
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Fecha de utlima atencion")]
        public DateOnly? UltimaAtencion { get; set; }
        #endregion
    }
}
