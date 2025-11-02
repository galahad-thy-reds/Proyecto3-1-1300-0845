using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3.Entidades.Clases
{
    /// <summary>
    /// Clase que representa un Cliente
    /// </summary>
    public class Cliente
    {
        #region Propiedades
        /// <summary>
        /// Cedula del Cliente
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Por favor, digite la cedula del cliente")]
        public string? Cedula { get; set; }
        /// <summary>
        /// Nombre completo del cliente
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite el nombre del cliente")]
        public string? Nombre { get; set; }
        /// <summary>
        /// Provincia de residencia del cliente
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite la provincia")]
        public string? Provincia { get; set; }
        /// <summary>
        /// Canton de residencia del cliente
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite el canton")]
        public string? Canton { get; set; }
        /// <summary>
        /// Distrito de residencia del cliente
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite el distrito")]
        public string? Distrito { get; set; }
        /// <summary>
        /// Direccion exacta de residencia del cliente
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite la direccion")]
        public string? Direccion { get; set; }
        /// <summary>
        /// Telefono de contacto del cliente
        /// </summary>
        [Required(ErrorMessage = "Por favor, digite un numero telefonico")]
        public string? Telefono { get; set; }
        /// <summary>
        /// Contacto preferido del cliente (llamada, mensaje WhatsApp)
        /// </summary>
        [Required(ErrorMessage = "Por favor, indique el metodo de contacto preferido")]
        [DisplayName("Contacto Preferido")]
        public string? ContactoPreferido { get; set; }
        /// <summary>
        /// Lista de mascotas asociadas al cliente
        /// </summary>
        public List<Mascota>? Mascotas { get; set; } = [];
        #endregion
    }
}
