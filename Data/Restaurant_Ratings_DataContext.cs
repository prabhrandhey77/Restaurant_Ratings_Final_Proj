using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Ratings_Final_Proj.Models;

namespace Restaurant_Ratings_Final_Proj.Models
{
    public class Restaurant_Ratings_DataContext : DbContext
    {
        public Restaurant_Ratings_DataContext (DbContextOptions<Restaurant_Ratings_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant_Ratings_Final_Proj.Models.Customer> Customer { get; set; }

        public DbSet<Restaurant_Ratings_Final_Proj.Models.Rating> Rating { get; set; }

        public DbSet<Restaurant_Ratings_Final_Proj.Models.Restaurant> Restaurant { get; set; }
    }
}
