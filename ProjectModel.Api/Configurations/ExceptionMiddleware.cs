using Microsoft.AspNetCore.Http;
using ProjectModel.Api.Model;
using ProjectModel.Infrastructure.Resources;
using System.Net;

namespace ProjectModel.Api.Configurations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IResources _resources;

        public ExceptionMiddleware(RequestDelegate requestDelegate, IResources resources)
        {
            _requestDelegate = requestDelegate;
            _resources = resources;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            // Obter o status code com base no tipo de exceção
            var errorDetailsResult = GetStatusCode(ex);

            context.Response.StatusCode = errorDetailsResult.StatusCode;

            await context.Response.WriteAsync(errorDetailsResult.ToString());
        }

        // Método para obter o status code com base no tipo de exceção
        private ErrorDetails GetStatusCode(Exception ex)
        {
            // Adicione lógica para mapear tipos de exceção para status code
            // Aqui está um exemplo simples para ilustração
            if (ex is UnauthorizedAccessException)
            {
                return new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Message = _resources.InternalServerError
                };
            }
            else if (ex is ArgumentException)
            {
                return new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = _resources.InternalServerError
                }; 
            }
            else
            {
                return new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = _resources.InternalServerError
                };
            }
        }
    }
}