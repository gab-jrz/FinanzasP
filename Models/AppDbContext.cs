using FinanzasPersonales.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Models
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            // Define las tablas (DbSet) de la base de datos
            public DbSet<Gasto> Gastos { get; set; } = default!;
        }
}


