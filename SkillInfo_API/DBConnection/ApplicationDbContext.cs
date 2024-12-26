using Microsoft.EntityFrameworkCore;
using SkillInfo_API.Entity;

namespace SkillInfo_API.DBConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Skill>()
        //        .ToTable("Skills")
        //        .HasKey(s => s.RefSourceId); // Adjust the key based on your design
        //}
    }
}
