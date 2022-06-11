using Microsoft.EntityFrameworkCore;

namespace CrudApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Model> Models { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<HistoryAction> HistoryActions { get; set; }

        public DbSet<History> Histories { get; set; }
    }
}
