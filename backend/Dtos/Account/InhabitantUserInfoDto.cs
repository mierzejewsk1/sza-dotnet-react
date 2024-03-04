using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Account
{
    public class InhabitantUserInfoDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? DepartmentName { get; set; }
        public string? MajorName { get; set; } 
    }
}