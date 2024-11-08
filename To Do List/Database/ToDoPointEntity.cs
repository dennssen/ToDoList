namespace To_Do_List.Database;

public class ToDoPointEntity
{
    public int? Id { get; set; }
    public required int ToDoListId { get; set; }
    public required ToDoListEntity ToDoList { get; set; }
    public required string Name { get; set; }
    public required bool Done { get; set; }
}