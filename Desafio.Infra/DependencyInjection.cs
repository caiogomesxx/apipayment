using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;
using Desafio.Infra.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Desafio.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesInfra(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddTransient<IVendedorRepository, VendedorRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IListaItensRepository, ListaItensRepository>();
            services.AddTransient<IVendaRepository, VendaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
          
 
            services.AddDbContext<AppDbContext>(options =>
                   options.UseMySql("Server=LocalHost; Database=LocalDatabase; User=root; Password=1234;", new MySqlServerVersion(new Version())));


            return services;
        }
    }
}
