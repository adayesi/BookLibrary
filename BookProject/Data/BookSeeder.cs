using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace Data
{
    public class BookSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                        {
                            Id = "1",
                            Title = "Lost In Time",
                            Description = "Book for the soul",
                            Genre = "Biography",
                            CoverUrl = "http...",
                            Author = "Murphy",
                            ISBN = "978-1-60309-265-4",
                            PublishedAt = DateTime.Now.AddYears(-5)
                            

                        },
                        new Book()
                        {
                            Id = "2",
                            Title = "Shrek",
                            Description = "Best animation of all time",
                            Genre = "Animation",
                            CoverUrl = "http...",
                            Author = "Artemis",
                            ISBN = "978-1-60309-025-4",
                            PublishedAt = DateTime.Now.AddYears(-5)

                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
