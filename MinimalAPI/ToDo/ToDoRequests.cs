namespace MinimalAPI;

public static class ToDoRequests
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/todos", GetAll)
            .Produces<List<ToDo>>()
            .WithTags("To Dos");
        
        app.MapGet("/todos/{id}", GetById)
            .Produces<ToDo>()
            .Produces(statusCode: 404)
            .WithTags("To Dos");

        app.MapPost("/todos", Create)
            .Produces(statusCode: 201)
            .Accepts<ToDo>("application/json")
            .WithValidator<ToDo>()
            .WithTags("To Dos");

        app.MapPut("/todos/{id}", Update)
            .Produces(statusCode: 204)
            .Produces(statusCode: 404)
            .Accepts<ToDo>("application/json")
            .WithValidator<ToDo>()
            .WithTags("To Dos");

        app.MapDelete("/todos/{id}", Delete)
            .Produces(statusCode: 204)
            .Produces(statusCode: 404)
            .WithTags("To Dos");

        return app;
    }

    public static IResult GetAll(IToDoService service)
    {
        var toDos = service.GetAll();

        return Results.Ok(toDos);
    }

    public static IResult GetById(IToDoService service, Guid id)
    {
        var todo = service.GetById(id);

        if(todo == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(todo);    
    }

    public static IResult Create(IToDoService service, ToDo todo)
    {
        service.Create(todo);

        return Results.Created($"/todos/{todo.Id}", todo);
    }

    public static IResult Update(IToDoService service, Guid id, ToDo toDo)
    {
        var todo = service.GetById(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        service.Update(toDo);

        return Results.NoContent();
    }

    public static IResult Delete(IToDoService service, Guid id)
    {
        var todo = service.GetById(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        service.Delete(id);

        return Results.NoContent();
    }
}
