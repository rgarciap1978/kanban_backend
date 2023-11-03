using KanbanBoard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KanbanBoard.DataAccess.Seeds
{
    public class PrioritySeed : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            
            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(5, 1);

            builder
                .HasData(
                new Priority() { Id = 1, Name = "Urgent", Color = "FF0000", Status = true },
                new Priority() { Id = 2, Name = "Standard", Color = "00FF00", Status = true },
                new Priority() { Id = 3, Name = "Deadline", Color = "FFFF00", Status = true },
                new Priority() { Id = 4, Name = "Internal", Color = "0000FF", Status = true }
            );
                
        }
    }
}
