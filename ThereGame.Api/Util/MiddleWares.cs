using System.Net;

namespace Microsoft.AspNetCore.Builder;

public static class WebApplicationMiddleWare
{
    public static WebApplication UseThereGameAuth(this WebApplication app)
    {
        // app.Use(async (context, next) =>
        // {
        //     if (context.Request.Path.StartsWithSegments("auth"))
        //     {
        //         await next.Invoke();
        //         return;
        //     }

        //     var auth = context.Request.Headers.FirstOrDefault(header => header.Key == "X-THEREGAME-AUTH");
        //     if (auth.Key == null) {
        //         context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //     }

        //     await next.Invoke();
        // });

        return app;
    }
}