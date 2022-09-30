using Album.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Album.Data
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddContextConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AlbumContext>(option => option.UseSqlServer(configuration.GetConnectionString(nameof(AlbumContext))));
            return service;

        }
    }
}