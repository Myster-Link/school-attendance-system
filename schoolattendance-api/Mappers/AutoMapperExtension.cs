using Mappers.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Mappers
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperExtension(this IServiceCollection services)
        {
            services.AddTransient<IMapperAdapter, MapperAdapter>();
            services.AddAutoMapper(typeof(UserMappingProfile));

            return services;
        }
    }
}
