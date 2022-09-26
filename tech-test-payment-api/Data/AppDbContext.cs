using Microsoft.EntityFrameworkCore;
using Desafio.Models;

namespace Desafio.Data
{
    public class AppDbContext : DbContext
    {
        

        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Vendedor>? Vendedor { get; set; }
        public DbSet<ListaItens>? ListaItens { get; set; }
        public DbSet<Venda>? Venda { get; set; }
        public DbSet<Produto>? Produto { get; set; }
    }
}
