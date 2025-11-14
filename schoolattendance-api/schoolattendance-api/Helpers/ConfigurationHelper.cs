namespace schoolattendance_api.Helpers
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static string GetConfigValue(string envKey, string configKey)
            => Environment.GetEnvironmentVariable(envKey)
               ?? _configuration[configKey]
               ?? throw new InvalidOperationException($"Configuration value for {configKey} is missing.");

        public static void SetConfigValue(IConfiguration configuration)
            => _configuration = configuration;
    }
}
