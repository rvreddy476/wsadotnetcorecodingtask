namespace LocalFarm.WebAPI.Extensions
{
    static class CorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: "allOrigins",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                    });
            });
        }
    }
}
