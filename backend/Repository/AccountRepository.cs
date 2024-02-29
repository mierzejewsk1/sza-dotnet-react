using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;
       

        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
           
        }

        public async Task<Department?> GetDepartmentByIdAsync(int? id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == id);
        }

        public async Task<Major?> GetMajorByIdAsync(int? id)
        {
            return await _context.Majors.FirstOrDefaultAsync(m => m.MajorId == id);
        }
    }
}