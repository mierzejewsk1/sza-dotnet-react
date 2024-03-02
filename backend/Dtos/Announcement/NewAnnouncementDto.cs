using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Announcement
{
    public class NewAnnouncementDto
    {
        public string Subject { get; set; } = string.Empty;
        public string Descripton { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } 
    }
}