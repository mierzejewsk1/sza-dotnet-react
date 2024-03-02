using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Announcement
{
    public class UpdateAnnouncementDto
    {
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Descripton { get; set; }
    }
}