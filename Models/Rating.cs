using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Ratings_Final_Proj.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int RestaurantId { get; set; }

        public Customer Customer { get; set; }

        public Restaurant Restaurant { get; set; }

        [Range(0,5)]
        public decimal RatingValue { get; set; }

        public string Comment { get; set; }

    }
}
