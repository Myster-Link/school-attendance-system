using schoolattendance_api.Helpers;

namespace schoolattendance_api.Cors
{
    public static class CorsPolicyExtension
    {
        public static IServiceCollection AddCorsPolicyExtension(this IServiceCollection services, string myAllowSpecificOrigins)
        {
            var frontEndUrl = ConfigurationHelper.GetConfigValue("CORS_SETTINGS_FRONTEND_URL", "CorsSettings:FrontEndUrl");

            services.AddCors(options =>
            {
                options.AddPolicy(name: myAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins(frontEndUrl, "http://localhost:3001")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .AllowCredentials();
                                  });
            });

            return services;
        }
    }
}
