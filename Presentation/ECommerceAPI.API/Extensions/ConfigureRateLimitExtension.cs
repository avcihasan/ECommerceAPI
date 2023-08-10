using AspNetCoreRateLimit;

namespace ECommerceAPI.API.Extensions
{
    public static class ConfigureRateLimitExtension
    {
        public static void AddRateLimit(this IServiceCollection services)
        {
            services.Configure<IpRateLimitOptions>(opts =>
            {
                opts.GeneralRules = new List<RateLimitRule>() { new()
                    {
                       Endpoint="*",
                       Limit=3,
                       Period ="1m"
                    }};
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }
    }
}
