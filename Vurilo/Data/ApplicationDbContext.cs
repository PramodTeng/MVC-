using Microsoft.EntityFrameworkCore;
using Vurilo.Models;

namespace Vurilo.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Search>Browse { get; set; }    
    }
}
