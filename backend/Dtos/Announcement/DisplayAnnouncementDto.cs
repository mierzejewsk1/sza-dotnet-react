using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Announcement
{
    public class DisplayAnnouncementDto
    {     
        public int Id {get; set; }
        public string? Subject { get; set; } = string.Empty;
        public string? Descripton { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? AppUserId { get; set; } = string.Empty;
        public string? AppUsername { get; set; } = string.Empty;
    }
}