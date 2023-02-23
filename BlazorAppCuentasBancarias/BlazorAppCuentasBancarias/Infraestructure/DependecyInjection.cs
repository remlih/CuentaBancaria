using BlazorAppCuentasBancarias.Data;
using BlazorAppCuentasBancarias.Interfaces;
using BlazorAppCuentasBancarias.Repository;
using BlazorAppCuentasBancarias.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppCuentasBancarias.Infraestructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<ICuentaBancariaService, CuentaBancariaService>();
            //services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddDbContext<BancoContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("BankDatabase"));
            });
            return services;
        }
    }
}
