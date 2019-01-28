using Microsoft.EntityFrameworkCore;
    
namespace aureliadotnet.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options) : base(options) {}
        public DbSet<User> users { get; set; }

    }
}