using JT_InfoApi.Domain;
using JT_InfoApi.Domain.Entities;

namespace JT_InfoApi.API.Middlewares
{
    public class AuditMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuditMiddleware> _logger;

        public AuditMiddleware(RequestDelegate next, ILogger<AuditMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            int? custCode = GetCustomerIdFromRequest(context);

            var endpoint = context.GetEndpoint();

            var controllerName = endpoint?.Metadata?
           .GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()?.ControllerName;

            var methodName = endpoint?.Metadata?
                .GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()?.ActionName;

            try
            {
                await _next(context);

                var log = new Audit
                {
                    CustCode = custCode,
                    MethodName = methodName,
                    ControllerName = controllerName,
                    HttpMethod = context.Request.Method,
                    StatusCode = context.Response.StatusCode,
                    Timestamp = DateTime.Now
                };

                db.Audits.Add(log);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error during API audit logging");

                var log = new Audit
                {
                    CustCode = custCode,
                    MethodName = methodName,
                    ControllerName = controllerName,
                    HttpMethod = context.Request.Method,
                    StatusCode = 500,
                    Timestamp = DateTime.Now
                };

                db.Audits.Add(log);
                await db.SaveChangesAsync();

                throw;
            }
        }

        private int? GetCustomerIdFromRequest(HttpContext context)
        {

            if (context.Request.Headers.TryGetValue("X-Cust-Code", out var headerValue))
            {
                if (int.TryParse(headerValue, out var id))
                    return id;
            }

            if (context.Request.Query.TryGetValue("custCode", out var queryValue))
            {
                if (int.TryParse(queryValue, out var id))
                    return id;
            }

            return null;
        }
    }

}
