using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DPNerd.Swagger.Core.Filters;

public class SwaggerDefaultValues : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var apiDescription = context.ApiDescription;
        operation.Deprecated |= apiDescription.IsDeprecated();

        if (operation.Parameters == null) return;

        foreach (var parameter in operation.Parameters)
        {
            var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

            var routeInfo = description.RouteInfo;

            if (parameter.Description == null)
                parameter.Description = description.ModelMetadata?.Description;

            if (routeInfo == null)
                continue;

            if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());

            parameter.Required |= !routeInfo.IsOptional;
        }
    }
}
