using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudApp.Models.Configuration
{
    public class HistoryActionConfiguration : IEntityTypeConfiguration<HistoryAction>
    {
        public void Configure(EntityTypeBuilder<HistoryAction> builder)
        {
            builder.HasData(
                new HistoryAction
                {
                    Id = 1,
                    Action = "Add"
                },
                new HistoryAction
                {
                    Id = 2,
                    Action = "Edit"
                },
                new HistoryAction
                {
                    Id = 3,
                    Action = "Delete"
                }
            );
        }
    }
}
