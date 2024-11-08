namespace To_Do_List.List;

public class Point(string name, bool done, int? id = null)
{
    public int? Id { get; set; } = id;
    public bool Done { get; set; } = done;
    public string Name { get; set; } = name;

}