using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TestApp.Entities;

namespace TestApp.DAL
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(
                serviceProvider.GetRequiredService<DbContextOptions<DBContext>>()))
            {
                if (context.Books.Any() && context.Types.Any())
                {
                    return;
                }

                context.Types.AddRange(
                    new BookTypeEntity
                    {
                        Id = 1,
                        TypeName = "Fantasy"
                    },
                    new BookTypeEntity
                    {
                        Id = 2,
                        TypeName = "Novel"
                    },
                    new BookTypeEntity
                    {
                        Id = 3,
                        TypeName = "Detective"
                    });
                
                context.Books.AddRange(
                    new BookEntity
                    {
                        Id = 1,
                        Title = "Harry Potter",
                        Author = "Joanne Rowling",
                        TypeId = 1
                    },
                    new BookEntity
                    {
                        Id = 2,
                        Title = "Charlie and the Chocolate Factory",
                        Author = "Roald Dahl",
                        TypeId = 2
                    },
                    new BookEntity
                    {
                        Id = 3,
                        Title = "Sherlock Holmes",
                        Author = "Sir Arthur Conan Doyle",
                        TypeId = 3
                    });

                context.SaveChanges();
            }
        }
    }
}
