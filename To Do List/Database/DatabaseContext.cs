using Microsoft.EntityFrameworkCore;

namespace To_Do_List.Database;

public class DatabaseContext : DbContext
{
    public DbSet<ToDoListEntity> ToDoLists { get; set; }
    public DbSet<ToDoPointEntity> ToDoPoints { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoListEntityConfiguration).Assembly);
    }
}