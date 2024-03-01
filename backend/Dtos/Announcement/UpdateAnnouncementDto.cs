using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Announcement
{
    public class UpdateAnnouncementDto
    {
        public string? Subject { get; set; }
        public string? Descripton { get; set; }
    }
}