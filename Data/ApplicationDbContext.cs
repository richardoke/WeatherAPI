using Microsoft.EntityFrameworkCore;
using WeatherAPI.Entities;

namespace WeatherAPI.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {  }        
        
        public DbSet<WeatherCity> WeatherCity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
      
    }
}
