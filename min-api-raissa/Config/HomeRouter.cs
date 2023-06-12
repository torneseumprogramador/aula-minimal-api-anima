namespace min_api_raissa.Config;

public class HomeRouter
{

    public static void Register(WebApplication app)
    {
        app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                    return;
                }

                await next.Invoke();
            });
    }
}