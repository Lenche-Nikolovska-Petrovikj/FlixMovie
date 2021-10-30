using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class FlixmovieDbContextSeed
    { 
            public static async Task SeedAsync(FlixmovieDbContext flixmovieDbContext, ILoggerFactory loggerFactory, int? retry = 0)
            {
                int retryForAvailability = retry.Value;

                try
                {
                    // NOTE : Only run this if using a real database
                    flixmovieDbContext.Database.Migrate();
                    flixmovieDbContext.Database.EnsureCreated();

                    // seed Movies
                    await SeedMoviesAsync(flixmovieDbContext);


                }
                catch (Exception exception)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        var log = loggerFactory.CreateLogger<FlixmovieDbContext>();
                        log.LogError(exception.Message);
                        await SeedAsync(flixmovieDbContext, loggerFactory, retryForAvailability);
                    }
                    throw;
                }
            }

            private static async Task SeedMoviesAsync(FlixmovieDbContext flixmovieDbContext)
            {
                if (flixmovieDbContext.Movies.Any())
                    return;

            var movies = new List<Movie>(){
                new Movie()
                {   Title = "The Lord of the Rings: \n-The Fellowship of the Ring- ",
                    ReleaseDate= DateTime.Parse("2001-10-12"),
                    DurationInMinutes = "171 min",
                    Genre= "Adventure",
                    Director = "Peter Jackson",
                    InStock = 30,
                    ImageUrl = "~/images/poster-1.jpg"
                },
                new Movie()
                {   Title = "The Lord of the Rings: \n-The Two Towers- ",
                    ReleaseDate= DateTime.Parse("2002-05-12"),
                    DurationInMinutes = "171 min",
                    Genre= "Adventure",
                    Director = "Peter Jackson",
                    InStock = 30,
                    ImageUrl = "~/images/poster-2.jpg"
                },
                 new Movie()
                 {  Title = "The Lord of the Rings: \n-The Return of the King- ",
                    ReleaseDate= DateTime.Parse("2003-1-12"),
                    DurationInMinutes = "192 min",
                    Genre= "Adventure",
                    Director = "Peter Jackson",
                    InStock = 30,
                    ImageUrl = "~/images/poster-3.jpg"
                 },


                };
                flixmovieDbContext.Movies.AddRange(movies);
                await flixmovieDbContext.SaveChangesAsync();
            }
        }
    }

