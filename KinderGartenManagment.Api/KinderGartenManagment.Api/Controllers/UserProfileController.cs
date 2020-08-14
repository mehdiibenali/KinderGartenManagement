using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGartenManagment.Api.Constants;
using KinderGartenManagment.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<User> _userManager;
        public UserProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        //[HttpGet]
        //[Authorize(Roles = Role.User)]
        //[Route("ForUser")]
        //public string GetUser()
        //{
        //    return "Web method for User";
        //}

        //[HttpGet]
        //[Authorize(Roles = Role.User + "," + Role.Admin)]
        //[Route("ForAdminOrUser")]
        //public string GetForAdminOrCustome()
        //{
        //    return "Web method for Admin or Customer";
        //}
    }
}