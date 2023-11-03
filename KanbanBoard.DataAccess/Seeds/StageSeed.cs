using KanbanBoard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KanbanBoard.DataAccess.Seeds
{
    public class StageSeed : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn(5, 1);

            builder
                .HasData(
                new Stage() { Id = 1, Name = "To do", Position = 1, TemplateId = 1, Status = true },
                new Stage() { Id = 2, Name = "In progress", Position = 2, TemplateId = 1, Status = true },
                new Stage() { Id = 3, Name = "Code review", Position = 3, TemplateId = 1, Status = true },
                new Stage() { Id = 4, Name = "Done", Position = 4, TemplateId = 1, Status = true }
                );
        }
    }
}
