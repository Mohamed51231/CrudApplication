using Microsoft.EntityFrameworkCore;

namespace CrudApp.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<Model> Models { get; set; }
    }
}
