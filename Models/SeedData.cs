using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                {
                    context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Free",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "3monthly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Annual",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });

                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role
                        {
                            Name = "User"
                        },
                        new Role
                        {
                            Name = "StoreManager"
                        },
                        new Role
                        {
                            Name = "Owner"
                        }
                        );

                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Name = "Tatuazysta z Auschwitz",
                            AuthorName = "Heather Morris",
                            Genre = context.Genre.Where(g => g.Id == 1).SingleOrDefault(),
                            GenreId = 1,
                            DateAdded = new DateTime(2010, 12, 11),
                            ReleaseDate = new DateTime(2010, 12, 11),
                            NumberInStock = 20
                        },
                        new Book
                        {
                            Name = "Zmierzch",
                            AuthorName = "Meyer Stephenie",
                            Genre = context.Genre.Where(g => g.Id == 2).SingleOrDefault(),
                            GenreId = 2,
                            DateAdded = new DateTime(2007, 3, 17),
                            ReleaseDate = new DateTime(2007, 3, 17),
                            NumberInStock = 20,
                            NumberAvailable = 20
                        },
                        new Book
                        {
                            Name = "Wiedźmin",
                            AuthorName = "Sapkowski Andrzej",
                            Genre = context.Genre.Where(g => g.Id == 4).SingleOrDefault(),
                            GenreId = 4,
                            DateAdded = new DateTime(2016, 19, 12),
                            ReleaseDate = new DateTime(2016, 19, 12),
                            NumberInStock = 20,
                            NumberAvailable = 20
                        },
                        new Book
                        {
                            Name = "Krzyżacy",
                            AuthorName = "Sienkiewicz Henryk",
                            Genre = context.Genre.Where(g => g.Id == 2).SingleOrDefault(),
                            GenreId = 2,
                            DateAdded = new DateTime(2000, 13, 11),
                            ReleaseDate = new DateTime(2000, 19, 15),
                            NumberInStock = 20,
                            NumberAvailable = 20
                        },
                        new Book
                        {
                            Name = "Lalka",
                            AuthorName = "Prus Bolesław",
                            Genre = context.Genre.Where(g => g.Id == 4).SingleOrDefault(),
                            GenreId = 4,
                            DateAdded = new DateTime(1995, 9, 12),
                            ReleaseDate = new DateTime(1995, 9, 12),
                            NumberInStock = 20,
                            NumberAvailable = 20
                        }
                            );

                    context.SaveChanges();
                }
            }
        }
    }
}