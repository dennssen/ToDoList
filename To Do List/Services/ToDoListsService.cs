using To_Do_List.Database;
using To_Do_List.List;

namespace To_Do_List.Services;

public class ToDoListsService : IToDoListsService
{
    private readonly DatabaseContext _context;

    public ToDoListsService(DatabaseContext context)
    {
        _context = context;
    }

    public void CreateToDoList(ToDoList toDoList)
    {
        ToDoListEntity newList = new ToDoListEntity() { Title = toDoList.Title, Color = toDoList.Color };
        _context.ToDoLists.Add(newList);
        _context.SaveChanges();

        toDoList.Id = newList.Id;
        
        foreach (var point in toDoList.Points)
        {
            ToDoPointEntity newPoint = new ToDoPointEntity()
                { Name = point.Name, Done = point.Done, ToDoListId = (int)newList.Id!, ToDoList = newList };
            _context.ToDoPoints.Add(newPoint);
            _context.SaveChanges();

            point.Id = newPoint.Id;
        }
    }

    public void UpdateToDoList(ToDoList toDoList)
    {
        ToDoListEntity toBeUpdated = GetListEntityById((int)toDoList.Id!)!;
        toBeUpdated.Title = toDoList.Title;
        toBeUpdated.Color = toDoList.Color;

        _context.SaveChanges();

        List<ToDoPointEntity> newPointList = new List<ToDoPointEntity>();

        foreach (var point in toDoList.Points)
        {
            newPointList.Add(new ToDoPointEntity()
                { Name = point.Name, Done = point.Done, ToDoListId = (int)toBeUpdated.Id!, ToDoList = toBeUpdated });
        }

        toBeUpdated.Points = newPointList;
        _context.SaveChanges();
    }

    public void DeleteToDoList(ToDoList toDoList)
    {
        List<Point> pointsList = toDoList.Points;
        foreach (var point in pointsList)
        {
            _context.ToDoPoints.Remove(GetPointEntityById((int)point.Id!)!);
        }

        _context.ToDoLists.Remove(GetListEntityById((int)toDoList.Id!)!);
        _context.SaveChanges();
    }

    public List<ToDoList> GetToDoLists()
    {
        List<ToDoList> toDoLists = new List<ToDoList>();

        foreach (ToDoListEntity toDoListEntity in _context.ToDoLists)
        {
            List<Point> toDoPoints = new List<Point>();

            foreach (ToDoPointEntity toDoPointEntity in _context.ToDoPoints)
            {
                if (toDoPointEntity.ToDoListId == toDoListEntity.Id)
                {
                    toDoPoints.Add(new Point(toDoPointEntity.Name, toDoPointEntity.Done, toDoPointEntity.Id));
                }
            }

            toDoLists.Add(new ToDoList(toDoListEntity.Title, toDoListEntity.Color, toDoPoints, toDoListEntity.Id));
        }

        return toDoLists;
    }

    private ToDoPointEntity? GetPointEntityById(int id)
    {
        return _context.ToDoPoints.FirstOrDefault(pointEntity => pointEntity.Id == id);
    }

    private ToDoListEntity? GetListEntityById(int id)
    {
        return _context.ToDoLists.FirstOrDefault(listEntity => listEntity.Id == id);
    }

    public void UpdatePoint(int pointId, bool done)
    {
        ToDoPointEntity? pointEntity = GetPointEntityById(pointId);
        
        if (pointEntity == null) return;

        pointEntity.Done = done;
        _context.SaveChanges();
    }
}