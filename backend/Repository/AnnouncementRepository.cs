using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDBContext _context; 

        public AnnouncementRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Announcement> CreateAsync(Announcement announcementModel)
        {
            await _context.Announcements.AddAsync(announcementModel);
            await _context.SaveChangesAsync();
            return announcementModel;
        }

        public async Task<List<Announcement>> GetAllAsync()
        {
            return await _context.Announcements.ToListAsync();
        }
    }
}