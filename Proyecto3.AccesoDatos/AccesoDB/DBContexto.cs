using Microsoft.EntityFrameworkCore;
using Proyecto3.Entidades.Clases;

namespace Proyecto3.AccesoDatos.AccesoDB
{
    public class DBContexto(DbContextOptions<DBContexto> options) : DbContext(options)
    {
        public DbSet<Empleado> Empleados { get; set; }
    }
}
