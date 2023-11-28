namespace TheRestaurant.Presentation.Server.Config.Swagger
{
    public static class SwaggerServicesConfig
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
