using System;
using Microsoft.EntityFrameworkCore;
using uppgift1;

namespace uppgift1
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(

               new Course
               {
                   Id = 1,
                   Title = "C#",
                   Description = "Versatile programming language for building modern, scalable applications in .NET.",
                   StartDate = new DateTime(2020, 12, 10),
                   EndDate = new DateTime(2022, 6, 15)
               },
                new Course
                {
                    Id = 2,
                    Title = "Java",
                    Description = "Object-oriented language known for portability, performance, and extensive libraries.",
                    StartDate = new DateTime(2020, 9, 1),
                    EndDate = new DateTime(2022, 6, 15)
                },
                new Course
                {
                    Id = 3,
                    Title = "Python",
                    Description = "High-level, versatile language emphasizing readability and ease of use.",
                    StartDate = new DateTime(2020, 9, 1),
                    EndDate = new DateTime(2022, 6, 15)
                },
                new Course
                {
                    Id = 4,
                    Title = "C++",
                    Description = "Powerful language for system programming, game development, and high-performance applications.",
                    StartDate = new DateTime(2020, 9, 1),
                    EndDate = new DateTime(2022, 6, 15)
                },
                new Course
                {
                    Id = 5,
                    Title = "C",
                    Description = "Foundational programming language influencing many others; efficient and low-level.",
                    StartDate = new DateTime(2020, 9, 1),
                    EndDate = new DateTime(2022, 6, 15)
                }
            );
        }
    }
}