using schoolattendance_api.Mapper.Profiles;

namespace schoolattendance_api.Mapper
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
