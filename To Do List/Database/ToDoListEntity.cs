namespace To_Do_List.Database;

public class ToDoListEntity
{
    public int? Id { get; set; }
    public required string Title { get; set; }
    public required string Color { get; set; }
    public List<ToDoPointEntity> Points { get; set; } = new List<ToDoPointEntity>();
}