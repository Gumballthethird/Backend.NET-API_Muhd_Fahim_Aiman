using Microsoft.EntityFrameworkCore;
using FreelancerApp.Domain.Entities;


namespace FreelancerApp.Infrastructure.Data;

public class FreelancerDbContext : DbContext
{
    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Skillset> Skillsets { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }

    public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Freelancer>()
            .HasMany(f => f.Skillsets)
            .WithOne()
            .HasForeignKey(s => s.FreelancerId);

        modelBuilder.Entity<Freelancer>()
            .HasMany(f => f.Hobbies)
            .WithOne()
            .HasForeignKey(h => h.FreelancerId);

        modelBuilder.Entity<Hobby>()
            .HasOne(h => h.Freelancer)
            .WithMany(f => f.Hobbies)
            .HasForeignKey(h => h.FreelancerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Skillset>()
            .HasOne(s => s.Freelancer)
            .WithMany(f => f.Skillsets)
            .HasForeignKey(s => s.FreelancerId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}
