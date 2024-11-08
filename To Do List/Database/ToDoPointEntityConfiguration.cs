using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace To_Do_List.Database;

public class ToDoPointEntityConfiguration : IEntityTypeConfiguration<ToDoPointEntity>
{
    public void Configure(EntityTypeBuilder<ToDoPointEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.Name).IsRequired();
        builder.HasOne<ToDoListEntity>(x => x.ToDoList)
            .WithMany(x => x.Points)
            .HasForeignKey(x => x.ToDoListId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}