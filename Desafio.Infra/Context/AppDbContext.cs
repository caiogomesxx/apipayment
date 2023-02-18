using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Desafio.Infra.Context
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
            
                   options.UseMySql("Server=LocalHost; Database=LocalDatabase; User=root; Password=1234;", new MySqlServerVersion(new Version()), mySqlOptions =>
                   {
                      
                       mySqlOptions.EnableRetryOnFailure();
                   });
        }

        public DbSet<Vendedor>? Vendedor { get; set; }
        public DbSet<ListaItens>? ListaItens { get; set; }
        public DbSet<Venda>? Venda { get; set; }
        public DbSet<Produto>? Produto { get; set; }
    }
}
