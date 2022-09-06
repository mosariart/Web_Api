using Cinema_API.Data;
using Cinema_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private CinemaDbContext _dbContext;
        public MoviesController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            //return _dbContext.Movies.ToList();
            return Ok(_dbContext.Movies.ToList());
            //return StatusCode(StatusCodes.Status200OK);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movieToFind = _dbContext.Movies.Where(m => m.Id == id).First();
            if (movieToFind == null)
            {
                return NotFound("No content with this Id");
            }
            return Ok(movieToFind);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var movieToChange = _dbContext.Movies.Where(mov => mov.Id == id).First();
            if (movieToChange == null)
            {
                return NotFound("No record found with this Id");
            }
            else
            {
                movieToChange.Language = movie.Language;
                movieToChange.Name = movie.Name;
                _dbContext.SaveChanges();
                return Ok("Record Updated successfully");
            }

        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _dbContext.Movies.Where(mov => mov.Id == id).First();
            if (movieToDelete == null)
            {
                return NotFound("No record Was found with thid id");
            }
            else
            {
                _dbContext.Movies.Remove(movieToDelete);
                _dbContext.SaveChanges();
                return Ok();
            }

        }
    }
}
