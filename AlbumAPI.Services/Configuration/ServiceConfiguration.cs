using AlbumAPI.Services.Implementations;
using AlbumAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumAPI.Services.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddExternalServiceConfiguration
            (this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddTransient<IAlbumService, AlbumService>();                         
            return services;
        }

    }
}
