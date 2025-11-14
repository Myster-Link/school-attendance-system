using schoolattendance_api.Dtos.Common;
using schoolattendance_api.Exceptions;
using System.Net;
using System.Text.Json;

namespace schoolattendance_api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiErrorResponseDto();

                switch (error)
                {
                    case ApiException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        responseModel.Errors = e.Errors;
                        break;
                    case CustomValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        responseModel.Errors = e.Errors;
                        break;

                    case ApiExceptionNotFound e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Message = e.Message;
                        responseModel.Errors = e.Errors;
                        break;
                    case InternalServerException e:
                        // internal server error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message = e.Message;
                        responseModel.Errors = e.Errors;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message = error.Message;
                        break;
                }

                responseModel.Status = response.StatusCode;

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
