using Microsoft.EntityFrameworkCore;

namespace EntitySQLApiStudy.ApiStudy.Models
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        
    }
}
