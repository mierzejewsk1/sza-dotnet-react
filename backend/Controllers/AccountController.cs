using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using backend.Dtos.Account;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace backend.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)  
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) {
            try {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.EmailAddress,
                
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if(createdUser.Succeeded) {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, registerDto.Role);
                    if(roleResult.Succeeded) {
                        return Ok(
                            new NewUserDto {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.createToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else 
                {
                    return StatusCode(500, createdUser.Errors);
                }
            } catch(Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}