using Microsoft.EntityFrameworkCore;

namespace CRUDCsharp.Models
{
    public class StoreContext : DbContext
    {
       public StoreContext(DbContextOptions<StoreContext> options) : base(options) {
            
        }

        public DbSet<User> users { get; set; }
    }
}
