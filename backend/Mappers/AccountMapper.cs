using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Account;
using backend.Models;

namespace backend.Mappers
{
    public static class AccountMapper
    {
        public static InhabitantUserInfoDto ToInhabitantUserInfoDto(this AppUser appUser, Major major, Department department) {
            return new InhabitantUserInfoDto
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                DepartmentName = department.Name,
                MajorName = major.Name
            };
        }

          public static UserInfoDto ToUserInfoDto(this AppUser appUser) {
            return new UserInfoDto
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
            };
        }
    }
}