using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services_di_app.Models;
using services_di_app.Services;

namespace services_di_app.Controllers
{
    [Route("api/[controller]")] //http://localhost:5200/api/home
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService) //DI
        {
            _userService = userService;
        }
        
        //Method GET: http://localhost:5200/api/home
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        //Method GET: http://localhost:5200/api/home/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound(); //404
            }
            return Ok(user); //200
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var updatedUser = await _userService.UpdateAsync(id, user);
            if(updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}
