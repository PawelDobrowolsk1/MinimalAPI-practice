namespace MinimalAPI;

public static class ToDoRequests
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/todos", GetAll)
            .Produces<List<ToDo>>()
            .WithTags("To Dos");

        return app;
    }

    public static IResult GetAll(IToDoService service)
    {
        var toDos = service.GetAll();

        return Results.Ok(toDos);
    }
}
