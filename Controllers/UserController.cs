using Microsoft.AspNetCore.Mvc;
using BookAPI.Models;
using BookAPI.Models.UserModels;
namespace BookAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : Controller
    {
        [HttpPost("Login")]
        public IActionResult Login(User user) 
        {
            if (user == null) return NoContent();
            else
            {
                var loginAccount = new UserManagement().Login(user.UserID, user.Password);
                return Json(loginAccount);
            }
        }
    }
}
