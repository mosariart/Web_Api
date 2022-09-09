using Cinema_API.Data;
using Cinema_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private CinemaDbContext _dbContext;
        public UsersController(CinemaDbContext cinemaDbContext)
        {
            _dbContext = cinemaDbContext;
        }

        public IActionResult Register([FromBody]User user)
        {
            var userWithTheSameEmail = _dbContext.Users.Where(u => u.Id == user.Id).SingleOrDefault();
            if (userWithTheSameEmail != null)
            {
                return BadRequest("User with same email already exists");
            }
            var userObj = new User()
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Role = "Users"
            };
            _dbContext.Users.Add(userObj);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
