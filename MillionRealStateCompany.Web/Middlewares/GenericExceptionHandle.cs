using Microsoft.AspNetCore.Diagnostics;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Shared.Enums;

namespace MillionRealStateCompany.Web.Middlewares
{
    public sealed class GenericExceptionHandle(ILogger<GenericExceptionHandle> logger) : IExceptionHandler
    {
        
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Guid codeGenerated = Guid.NewGuid();
            logger.LogError(exception, "Exception occurred:  Code: --- {codeGenetared} --- {Message}}", codeGenerated, exception.Message);

            CustomErrorResponse customErrorResponse = new CustomErrorResponse
            {
                Code = (int)CodesResponse.NOK,
                Message = "Error occurred in the process, see generated code",
                ErrorCode = codeGenerated
            };

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response
                .WriteAsJsonAsync(customErrorResponse, cancellationToken);

            return true;
        }
    }
}
