using Cinema_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_API.Data
{
    public class CinemaDbContext: DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies{ get; set; }

    }
}
