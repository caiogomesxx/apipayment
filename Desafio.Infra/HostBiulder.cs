using Microsoft.AspNetCore;

namespace Desafio.Infra
{
    public class HostBiulder
    {
         
        public HostBiulder() 
        {
            
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .UseStartup<Program>();
    }
}
