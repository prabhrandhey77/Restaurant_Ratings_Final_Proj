using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Ratings_Final_Proj.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string RegistredName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Since { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }


        [NotMapped]
        public decimal OverallRating { get; set; }


    }
}
