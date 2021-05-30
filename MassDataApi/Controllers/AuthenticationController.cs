using AutoMapper;
using MassDataApi.Data.Entities;
using MassDataApi.Service.MassService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationController(IMapper mapper, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpPost("PostRegistration")]
        public async Task<IActionResult> MakeRegistration(Authentication auth)
        {
            try
            {
                
                var user = new IdentityUser
                {
                    UserName = auth.Email,
                    Email = auth.Email,
                };
                IdentityRole identityRole = new IdentityRole
                {
                    Name = auth.Role,
                };
                var result = await _userManager.CreateAsync(user,auth.Password);
                var res = await _roleManager.CreateAsync(identityRole);
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("PostLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Authentication auth)
        {
            try
            {
                //var res = await _roleManager.RoleExistsAsync(auth.Role);
                var result = await _signInManager.PasswordSignInAsync(auth.Email, auth.Password, auth.RememberMe, false);
                if (result != null)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
