using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Dtos.Announcement;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;


namespace backend.Mappers
{
    public static class AnnouncementMapper
    {
        public static DisplayAnnouncementDto ToAnnouncementDto(this Announcement announcement) {
            return new DisplayAnnouncementDto {
                Id = announcement.Id,
                Subject = announcement.Subject,
                Descripton = announcement.Descripton,
                AppUserId = announcement.AppUserId,
                AppUsername = announcement?.AppUser?.UserName,
            };
        }

        public static Announcement ToAnnouncementFromAnnounementDto(this AddAnnouncementDto announcementDto) {
            return new Announcement
            {
                Subject = announcementDto.Subject,
                Descripton = announcementDto.Descripton,
                CreatedOn = DateTime.Now,
            };
        }

        public static Announcement ToAnnouncementFromUpdate(this UpdateAnnouncementDto announcementDto) {
            
            return new Announcement 
            {
                Subject = announcementDto.Subject!,
                Descripton = announcementDto.Descripton!,
            };
        }
    }
}