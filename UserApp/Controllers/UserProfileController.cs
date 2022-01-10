using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace UserApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<User> _userManager;

        public UserProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Route("Profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //GET: /User/Profile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type  == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Object> GetUserById(string id)
          {
            var user = await _userManager.FindByIdAsync(id);

            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}
