using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace To_Do_List.Database;

public class ToDoListEntityConfiguration : IEntityTypeConfiguration<ToDoListEntity>
{
    public void Configure(EntityTypeBuilder<ToDoListEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Color).IsRequired();
        builder.HasMany<ToDoPointEntity>(x => x.Points)
            .WithOne(x => x.ToDoList)
            .HasForeignKey(x => x.ToDoListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}