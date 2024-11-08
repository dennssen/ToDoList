using To_Do_List.Database;
using To_Do_List.List;

namespace To_Do_List.Services;

public interface IToDoListsService
{
    public void CreateToDoList(ToDoList toDoList);
    public void UpdateToDoList(ToDoList toDoList);
    public void DeleteToDoList(ToDoList toDoList);
    public List<ToDoList> GetToDoLists();
    public void UpdatePoint(int id, bool done);

}