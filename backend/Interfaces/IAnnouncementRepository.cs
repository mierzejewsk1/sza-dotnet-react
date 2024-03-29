using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAllAsync();
        Task<Announcement?> CreateAsync(Announcement announcement);
        Task<Announcement?> GetByIdAsync(int id);
        Task<Announcement?> DeleteAsync(int id);
        Task<Announcement?> UpdateAsync(int id, Announcement announcementModel);
    }
}