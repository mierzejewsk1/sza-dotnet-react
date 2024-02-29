using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Dtos.Announcement;
using System.Security.Cryptography;


namespace backend.Mappers
{
    public static class AnnouncementMapper
    {
        public static DisplayAnnouncementDto ToAnnouncementDto(this Announcement announcement, string username) {
            return new DisplayAnnouncementDto {
                Subject = announcement.Subject,
                Descripton = announcement.Descripton,
                AppUserId = announcement.AppUserId,
                AppUsername = username
            };
        }

        public static Announcement ToAnnouncementFromAnnounementDto(this AddAnnouncementDto announcementDto, string AppUserId) {
            return new Announcement
            {
                Subject = announcementDto.Subject,
                Descripton = announcementDto.Descripton,
                AppUserId = AppUserId,
                CreatedOn = DateTime.Now,

            };
        }
    }
}