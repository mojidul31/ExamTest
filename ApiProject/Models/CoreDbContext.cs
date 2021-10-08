using Microsoft.EntityFrameworkCore;

namespace ApiProject.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonHistory> PersonHistory { get; set; }
    }
}
