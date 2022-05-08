using DPNerd.Swagger.Core.Filters;
using DPNerd.Swagger.Core.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace DPNerd.Swagger.Core.Configurations;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, bool useApiSecurity = true)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(IServiceCollection));

        var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        services.AddVersioningConfiguration();

        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        services.AddSwaggerGen(c =>
        {
            c.OperationFilter<SwaggerDefaultValues>();

            if (useApiSecurity)
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            }
            try
            {
                c.IncludeXmlComments(xmlPath);
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("WARNING");
                Console.ResetColor();
                Console.Write($" - {nameof(xmlPath)} não localizado em {xmlPath}, verifique se existe a tag <GenerateDocumentationFile>true</GenerateDocumentationFile> no .csproj do projeto");
            }
        });
        return services;
    }

    public static IServiceCollection AddVersioningConfiguration(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(IServiceCollection));

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(IApplicationBuilder));

        if (provider == null)
            throw new ArgumentNullException(nameof(IApiVersionDescriptionProvider));

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                string isDeprecated = description.IsDeprecated ? " (DESCONTINUADO)" : string.Empty;

                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant() + isDeprecated);
            }
        });
        return app;
    }
}
