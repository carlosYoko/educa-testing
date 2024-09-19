using EducaTesting.Domain;
using Microsoft.EntityFrameworkCore;

namespace EducaTesting.Persistence
{
    public class EducaTestingDbContext : DbContext
    {
        public EducaTestingDbContext(DbContextOptions<EducaTestingDbContext> options) : base(options)
        { }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(x => x.Price)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso C#",
                    Title = "C#",
                    DateCreation = DateTime.Now,
                    DatePublication = DateTime.Now.AddYears(2),
                    Price = 59,
                });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso TypeScript",
                    Title = "TS",
                    DateCreation = DateTime.Now,
                    DatePublication = DateTime.Now.AddYears(2),
                    Price = 19,
                });

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso Unit Test .NET",
                    Title = "Testing .NET",
                    DateCreation = DateTime.Now,
                    DatePublication = DateTime.Now.AddYears(2),
                    Price = 159,
                });
        }
    }
}
