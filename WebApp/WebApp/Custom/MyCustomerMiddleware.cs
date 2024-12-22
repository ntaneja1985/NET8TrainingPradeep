namespace WebApp.Custom
{
    public class MyCustomerMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request information
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the response information
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}
