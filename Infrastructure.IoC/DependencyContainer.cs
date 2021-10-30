using Application.Interfaces;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterIoCServices(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICustomerService, CustomerService>();

            // Domain.Interfaces > Infra.Data.Repositories
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }
    }
}
