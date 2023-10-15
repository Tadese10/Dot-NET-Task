
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNETTask.Infrastructure.Middleware;
using DotNETTask.Persistence.Context;
using DotNETTask.Persistence.Interfaces.Repositories;
using DotNETTask.Persistence.Interfaces.Services;
using DotNETTask.Persistence.Repositories;
using DotNETTask.Core.Services;

namespace DotNETTask.Infrastructure.Extentions
{
    public static class DependencyInjection
    {
		public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseCosmos(
					configuration["Cosmos:AccountEndpoint"],
					configuration["Cosmos:AccountKey"],
					configuration["Cosmos:DatabaseName"])
			);
			services
				.AddScoped<IProviderRepository, ProviderRepository>();

            services.AddScoped<DtoValidationFilterAttribute>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public static void AddCoreServices(this IServiceCollection services)
        {
            services
                .AddScoped<IProviderService, ProviderService>();
        }
    }
}
