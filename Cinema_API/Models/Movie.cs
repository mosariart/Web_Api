using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_API.Models
{
    public class Movie
    {
        //just to make sure we are not getting any empty or null information from the client
        public int Id { get; set; }
        [Required(ErrorMessage ="Name cannot be null or empty")]
        //you can fill other properties with empty or null errors too.
        public string Language { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Rating { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
