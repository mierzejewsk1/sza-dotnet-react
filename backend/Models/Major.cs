using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Major
    {
        public int MajorId { get; set; }
        public string Name { get; set; }  = string.Empty;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }        
    }
}