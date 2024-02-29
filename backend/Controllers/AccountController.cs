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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using backend.Mappers;
using backend.Data;
using backend.Repository;

namespace backend.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IAccountRepository _accountRepo;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signinManager, IAccountRepository accountRepo)  
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;
            _accountRepo = accountRepo;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email!.ToLower());

            if(user == null) return Unauthorized("Invalid email");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);

            if(!result.Succeeded) return Unauthorized("Username not found and/or inncorrect password");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.createToken(user)
                }
            );            
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
                    MajorId = registerDto.MajorId,
                
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);

                if(createdUser.Succeeded) {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, registerDto.Role!);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfo([FromRoute] string id) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(user == null)
                return NotFound("No account with this ID");
           
            if(user.MajorId == null) 
                return Ok(user.ToUserInfoDto());


            var major = await _accountRepo.GetMajorByIdAsync(user.MajorId);
        
            var department = await _accountRepo.GetDepartmentByIdAsync(major!.DepartmentId);
            
            var userDto = user.ToInhabitantUserInfoDto(major, department!);

            return Ok(userDto);
        }
    }
}