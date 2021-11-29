using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCDEMO.Models;
using MVCDEMO.Data;
using System;
using System.Linq;

namespace MVCDEMO.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDBContext>>()))
            {
                // Look for any movies.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        StudentId = "STD05",
                        StudentName = "Nguyễn NT",
                        address = "Nam Định",

                    },

                    new Student
                    {
                        StudentId = "STD06",
                        StudentName = "Hải Anh",
                        address = "Hà Nội",

                    },

                    new Student
                    {
                        StudentId = "STD07",
                        StudentName = "Nam",
                        address = "Hà Nội",

                    },

                    new Student
                    {
                        StudentId = "STD08",
                        StudentName = "Nhi",
                        address = "Hà Nội",

                    }
                );
                context.Movie.AddRange(
                    new Movie
                    {
                         Title = "When Harry Met Sally",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Romantic Comedy",
                         Rating = "R",
                         Price = 7.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}