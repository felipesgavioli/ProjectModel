using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerLanguageOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var supportedLanguages = new List<string> { "en-US", "pt-BR" }; // Adicione os idiomas suportados aqui
        var languageParameter = new OpenApiParameter
        {
            Name = "language",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Enum = supportedLanguages.Select(lang => new OpenApiString(lang) as IOpenApiAny).ToList(),
                Default = new OpenApiString("en-US") // Idioma padrão
            },
            Description = "Language (en-US, pt-BR)"
        };

        operation.Parameters.Add(languageParameter);
    }
}