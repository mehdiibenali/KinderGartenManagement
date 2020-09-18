using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KinderGartenManagment.Api.Constants;
using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Net.Http.Headers;
using KinderGartenManagment.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KinderGartenManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private ApplicationDbContext _context;
        public ApplicationUserController(UserManager<User> userManager,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(UserViewModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePicture = model.ProfilePicture,
                Email = model.Email
            };
            try
            {
                var userCreateResult = await _userManager.CreateAsync(user, model.Password);
                if (userCreateResult.Succeeded)
                {
                    var roleCreated = await _userManager.AddToRoleAsync(user, model.Role);
                    return Ok(new { message = "success" });
                }
                return userCreateResult.Errors;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault()),
                        new Claim("username",user.UserName),
                        new Claim("fullName",user.FirstName + " " + user.LastName),
                        new Claim("ProfilePicture", user.ProfilePicture)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtLocalConstants.SecretKey)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var auth_token = tokenHandler.WriteToken(securityToken);
                return Ok(new { auth_token });
            }
            //else
            return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [Route("GetByUserName/{username}")]
        //GET : /api/ApplicationUser/GetByUserName/UserName
        public async Task<ActionResult<UserViewModel>> GetByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            var role = await _userManager.GetRolesAsync(user);
            var result = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture,
                UserName = user.UserName,
                Email = user.Email,
                Role = role[0],
            };
            return result;
        }
        [HttpGet]
        [Route("GetAll")]
        //GET : /api/ApplicationUser/GetByUserName/UserName
        public async Task<ActionResult<UserViewModel>> GetAll()
        {
            //var user = _userManager.Users.ToList();
            //var users = await _context.Users.ToListAsync();
            var users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
            if (users == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<List<UserViewModel>>(users);
        
            return Ok(result);


        }
        [HttpPut]
        [Authorize(Roles = Roles.Admin)]
        [Route("Update/{username}")]
        public async Task<ActionResult<UserViewModel>> Update(string username, UserViewModel model)
        {
            var user = await _userManager.FindByNameAsync(username);    
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.ProfilePicture = model.ProfilePicture;
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRoleAsync(user, model.Role);
                await _userManager.UpdateAsync(user);
                var result = _mapper.Map<UserViewModel>(user);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Authorize(Roles = Roles.Admin)]
        [Route("Delete/{username}")]
        public async Task<ActionResult<UserViewModel>> Delete(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                var USER = user;
                await _userManager.DeleteAsync(user);
                return Ok(new { USER, message = "Deleted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Route("ChangePassword/{username}/{password}/{newpassword}")]
        public async Task<ActionResult<UserViewModel>> ChangePassword(string username, string password, string newpassword)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                await _userManager.ChangePasswordAsync(user, password, newpassword);
                return Ok(new {  message = "Changed Successfully \n new password = "+newpassword });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = "C:/Users/ASUS/Desktop/Project/KinderGarten/KinderGartenManagementAngular/src/assets";
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = pathToSave+"/"+fileName;
                    var dbPath = "assets/"+fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                        return Ok(new { dbPath });
                    //return StatusCode(200, dbPath) ;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
