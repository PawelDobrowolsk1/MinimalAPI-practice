namespace MinimalAPI;

public interface IToDoService
{
    void Create(ToDo toDo);
    void Delete(Guid id);
    List<ToDo> GetAll();
    ToDo GetById(Guid id);
    void Update(ToDo toDo);
}

public class ToDoService : IToDoService
{
    private readonly Dictionary<Guid, ToDo> _toDos = new();

    public ToDoService()
    {
        var sampleToDo = new ToDo { Value = "Learn MinimalAPI" };
        _toDos[sampleToDo.Id] = sampleToDo;
    }

    public List<ToDo> GetAll()
    {
        return _toDos.Values.ToList();
    }

    public ToDo GetById(Guid id)
    {
        return _toDos.GetValueOrDefault(id);
    }

    public void Create(ToDo toDo)
    {
        if (toDo is null)
        {
            return;
        }

        _toDos.Add(toDo.Id, toDo);
    }

    public void Update(ToDo toDo)
    {
        var exsitingDoTo = GetById(toDo.Id);

        if (exsitingDoTo is null)
        {
            return;
        }

        _toDos[toDo.Id] = toDo;
    }

    public void Delete(Guid id)
    {
        _toDos.Remove(id);
    }
}
