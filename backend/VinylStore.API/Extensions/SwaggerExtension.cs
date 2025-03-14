using System.Reflection;
using Microsoft.OpenApi.Models;

namespace VinylStore.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Vinyl Store API",
                Version = "v1",
                Description = "API for Vinyl Store (with YouTube integration)",
                Contact = new OpenApiContact { Name = "Zemlyanikin" }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vinyl API v1");
            c.RoutePrefix = "api-docs";
            c.DocumentTitle = "Vinyl Store API Documentation";
        });

        var environment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
        if (environment.IsDevelopment())
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/api-docs");
                    return;
                }

                await next();
            });
        }

        return app;
    }
}