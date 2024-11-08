using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_List.List;
using To_Do_List.Services;

namespace To_Do_List.Pages;

public class IndexModel : PageModel
{
    public List<ToDoList> TodoLists { get; set; }
    
    [BindProperty]
    public string FormName { get; set; }
    
    [BindProperty]
    public string? Title { get; set; }
    [BindProperty]
    public string? Color { get; set; }
    [BindProperty]
    public string[]? PointNames { get; set; }
    [BindProperty]
    public List<string>? PointDones { get; set; }

    [BindProperty] 
    public int? PointId { get; set; }
    [BindProperty] 
    public string? PointDone { get; set; }
    
    [BindProperty]
    public int? ListId { get; set; }

    private readonly ILogger<IndexModel> _logger;
    private readonly IToDoListsService _service;

    public IndexModel(ILogger<IndexModel> logger, IToDoListsService service)
    {
        _logger = logger;
        _service = service;
    }
    
    public void OnGet()
    {
        TodoLists = _service.GetToDoLists();
    }

    public void OnPost()
    {
        if (FormName == "NewListForm")
        {
            CreateNewList();
        }
        else if (FormName == "EditListForm")
        {
            FixPointDones();
            UpdateList();
        }
        else if (FormName == "UpdatePointForm")
        {
            UpdatePoint();
        }
        else if (FormName == "DeleteListForm")
        {
            DeleteList();
        }
        
        TodoLists = _service.GetToDoLists();
    }

    public void FixPointDones()
    {
        if (PointDones is not { Count: >= 1 }) return;
        
        for (int i = 0; i < PointDones.Count; i++)
        {
            if (PointDones[i] == "on")
            {
                PointDones.RemoveAt(i - 1);
            }
        }
    }

    public void CreateNewList()
    {
        List<Point> pointList = new List<Point>();
        foreach (var pointName in PointNames!)
        {
            Point newPoint = new Point(pointName, false);
            pointList.Add(newPoint);
        }
        
        ToDoList newList = new ToDoList(Title!, Color!, pointList);
        
        _service.CreateToDoList(newList);
    }

    public void UpdateList()
    {
        TodoLists = _service.GetToDoLists();
        ToDoList? toBeUpdated = null;
        foreach (var list in TodoLists)
        {
            if (list.Id == ListId)
            {
                toBeUpdated = list;
                break;
            }
        }

        if (toBeUpdated == null) return;

        toBeUpdated.Title = Title;
        toBeUpdated.Color = Color;

        List<Point> newPoints = new List<Point>();

        if (PointNames is { Length: >= 1 })
        {
            for (int i = 0; i < PointNames.Length; i++)
            {
                bool done = false || PointDones![i] == "on";
            
                Point newPoint = new Point(PointNames[i], done);
                newPoints.Add(newPoint);
            }
        }
        
        toBeUpdated.Points = newPoints;
        _service.UpdateToDoList(toBeUpdated);
    }

    public void DeleteList()
    {
        TodoLists = _service.GetToDoLists();
        ToDoList? toBeDeleted = null;
        foreach (var list in TodoLists)
        {
            if (list.Id == ListId)
            {
                toBeDeleted = list;
                break;
            }
        }

        if (toBeDeleted == null) return;
        
        _service.DeleteToDoList(toBeDeleted);
    }

    public void UpdatePoint()
    {
        _service.UpdatePoint((int)PointId!, !string.IsNullOrEmpty(PointDone));
    }
}