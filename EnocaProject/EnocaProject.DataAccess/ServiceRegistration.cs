using System;
using System.Configuration;
using EnocaProject.Core.Repositories.Carrier;
using EnocaProject.Core.Repositories.CarrierConfiguration;
using EnocaProject.DataAccess.Contexts;
using EnocaProject.DataAccess.Repositories.Carrier;
using EnocaProject.DataAccess.Repositories.CarrierConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnocaProject.DataAccess
{
	public static class ServiceRegistration
	{
		public static void AddDataAccessServices(this IServiceCollection services)
		{
			services.AddDbContext<EnocaProjectDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            

            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
            services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
            services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();
        }
	}
}
