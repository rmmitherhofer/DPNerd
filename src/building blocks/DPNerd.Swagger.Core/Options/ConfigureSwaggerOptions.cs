using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace DPNerd.Swagger.Core.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            options.EnableAnnotations();
        }
    }

    public static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = Assembly.GetEntryAssembly().GetName().Name,
            Version = description.ApiVersion.ToString(),
            Contact = new OpenApiContact() { Name = "Renato Mitherhofer", Email = "renato.matos1@hotmail.com" },
            License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensourse.org/license/MIT") }
        };

        if (description.IsDeprecated)        
            info.Description += " Esta versão está obsoleta!";       

        return info;
    }
}
