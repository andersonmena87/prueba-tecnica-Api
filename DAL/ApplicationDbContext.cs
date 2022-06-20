using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
