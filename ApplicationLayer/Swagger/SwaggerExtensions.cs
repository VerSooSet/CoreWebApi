namespace ApplicationLayer.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "CoreWebApi",
                    Description = "This is demonstrate vers of app architecture based on features of CQS with using Microsoft DI as service provider",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Yuri",
                        Email = "kenrwork@gmail.com",
                        Url = new Uri("https://bitbucket.org/versoo")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "",
                        Url = new Uri("https://versoo.bibucket.org"),
                    }
                }); 
            }
            );
            return services;
        }

        public static WebApplication UseSwagger(WebApplication app)
        { 
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            return app;
        }
    }
}
