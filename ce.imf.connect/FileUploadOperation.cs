using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace ce.imf.connect
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParam = context.MethodInfo.GetParameters()
                .FirstOrDefault(p => p.ParameterType == typeof(IFormFile));

            if (fileParam == null)
                return;

            operation.RequestBody = new OpenApiRequestBody
            {
                Content = {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties =
                        {
                            [fileParam.Name] = new OpenApiSchema
                            {
                                Type = "string",
                                Format = "binary"
                            }
                        },
                        Required = { fileParam.Name }
                    }
                }
            }
            };
        }
    }
}




