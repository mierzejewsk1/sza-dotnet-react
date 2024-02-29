using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Interfaces
{
    public interface IAccountRepository
    {
        Task<Major?> GetMajorByIdAsync(int? id);
        Task<Department?> GetDepartmentByIdAsync(int? id);
    }
}