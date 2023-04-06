using System;
using System.Configuration;
using EnocaProject.Business.Abstract;
using EnocaProject.Business.Concrete;
using EnocaProject.Core.Repositories.Carrier;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnocaProject.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICarrierService, CarrierManager>();
            services.AddScoped<ICarrierConfigurationService, CarrierConfigurationManager>();

        }
    }
}
