using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace eCommerceAPI.Infrastructure.ExceptionHandling
{

    public class GlobalExceptionHandling
    {
        private RequestDelegate _next;

        public GlobalExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {

                await HandleExceptionAsyync(context, ex);
            }
        }

        public async Task HandleExceptionAsyync(HttpContext context, Exception exception)
        {
            context.Request.ContentType = "application/json";
            var response = context.Response;
            var responseModel = new ExceptionResponseModel();

            switch (exception)
            {
                case ApplicationException ex:
                    responseModel.ResponseCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.ResponseMessage = "Application Exception Occured! Please retry after somatime.";
                    break;
                case FileNotFoundException ex:
                    responseModel.ResponseCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.ResponseMessage = "The request resource is not found!";
                    break;
                default:
                    responseModel.ResponseCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.ResponseMessage = "Internal server error! Please retry after sometime.";
                    break;
            }

            var exceptionResult = JsonSerializer.Serialize(responseModel);
            await context.Response.WriteAsync(exceptionResult);
        }


    }
}
