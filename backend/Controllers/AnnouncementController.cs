using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using backend.Dtos.Announcement;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {   
        private readonly IAnnouncementRepository _announcementRepo;
        private readonly UserManager<AppUser> _userManager;

        public AnnouncementController(IAnnouncementRepository announcementRepo, UserManager<AppUser> userManager)
        {
            _announcementRepo = announcementRepo;
            _userManager = userManager;
        }

        
        [HttpGet("announcement")]
        [Authorize(Roles = "Administrator,Inhabitant")]
        public async Task<IActionResult> GetAnnouncements() {
            var announcements = await _announcementRepo.GetAllAsync();
            if(announcements == null) 
                return NotFound("There is no objects");
            
            var announcementDto = announcements.Select(a => a.ToAnnouncementDto(_userManager?.Users?.FirstOrDefault(u => u.Id == a.AppUserId)!.UserName!));
        
            return Ok(announcementDto);
        }  
        
       
        [HttpPost("announcement")]
        [Authorize(Roles = "Inhabitant")]
        public async Task<IActionResult> AddAnnouncement([FromBody] AddAnnouncementDto announcementDto) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.FindFirstValue(ClaimTypes.GivenName);
            
            var appUser = await _userManager.FindByNameAsync(username!);

            if(appUser == null)
                return BadRequest("Cant find user with this id");

            var announcementModel = announcementDto.ToAnnouncementFromAnnounementDto(appUser.Id);

            await _announcementRepo.CreateAsync(announcementModel);

            return Ok("Announcment addedd successfully");
            //return CreatedAtAction(nameof(GetById), new {id = announcementModel.Id}, announcementModel.ToAnnouncementDto());
        }


    }
}