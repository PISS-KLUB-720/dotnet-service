using Microsoft.EntityFrameworkCore;

namespace TennisServe.Database
{
    public class TennisDbContext : DbContext
    {
        public TennisDbContext(DbContextOptions<TennisDbContext> options) : base(options)
        {

        }
        public DbSet<PredictedServe> PredictedServes { get; set; }
    }
}
