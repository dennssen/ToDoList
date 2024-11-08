namespace To_Do_List.List;

public class ToDoList(string title, string color, List<Point> points, int? id = null)
{
    public int? Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Color { get; set; } = color;
    public List<Point> Points { get; set; } = points;
}