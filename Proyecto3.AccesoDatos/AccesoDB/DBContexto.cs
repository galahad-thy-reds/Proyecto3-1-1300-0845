using Microsoft.EntityFrameworkCore;
using Proyecto3.Entidades.Clases;

namespace Proyecto3.AccesoDatos.AccesoDB
{
    /// <summary>
    /// Clase de contexto de la base de datos
    /// </summary>
    /// <param name="options">Objeto DbContextOptions<DBContexto> para la injeccion de dependencias de las opciones</param>
    public class DBContexto(DbContextOptions<DBContexto> options) : DbContext(options)
    {
        /// <summary>
        /// DbSet de Empleados
        /// </summary>
        public DbSet<Empleado> Empleados { get; set; }
        /// <summary>
        /// DbSet de Clientes
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }
        /// <summary>
        /// DbSet de Mascotas
        /// </summary>
        public DbSet<Mascota> Mascotas { get; set; }
        /// <summary>
        /// Dbset de Procedimientos
        /// </summary>
        public DbSet<Procedimiento> Procedimientos { get; set; }
        /// <summary>
        /// Dbset de Tipo Procedimientos
        /// </summary>
        public DbSet<TipoProcedimiento> TiposProcedimiento { get; set; }
    }
}
