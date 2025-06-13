using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FreelancerApp.Infrastructure.Data;

namespace FreelancerApp.Infrastructure.Data
{
    public class FreelancerDbContextFactory : IDesignTimeDbContextFactory<FreelancerDbContext>
    {
        public FreelancerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FreelancerDbContext>();

            // Use SQLite or your configured database here
            optionsBuilder.UseSqlite("Data Source=freelancers.db");

            return new FreelancerDbContext(optionsBuilder.Options);
        }
    }
}
