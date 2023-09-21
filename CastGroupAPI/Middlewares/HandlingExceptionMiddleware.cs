using Application.Contracts;
using System.Net;
using System.Text.Json;

namespace CastGroupAPI.Middlewares
{
    public class HandlingExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<HandlingExceptionMiddleware> _logger;

        public HandlingExceptionMiddleware(ILogger<HandlingExceptionMiddleware> logger) =>
            _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var mensagem = e.Message;
                _logger.LogError(e, "Erro: {mensagem}", mensagem);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                string json = JsonSerializer.Serialize(new BaseDataResponse(context.Response.StatusCode, e.Message));
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}