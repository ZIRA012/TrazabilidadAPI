using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrazabilidadAPI.Application.DTOs;
using TrazabilidadAPI.Application.Interfaces;
using TrazabilidadAPI.Domain.Entities;
using TrazabilidadAPI.Infrastructure.Data;
using TrazabilidadAPI.SharedLibraries.OperationResults;

namespace TrazabilidadAPI.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<string?> GetUserRoleByEmailAsync(string email)
        {
            return await context.Users
                .Where(u => u.Email == email)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .SelectMany(u => u.UserRoles.Select(ur => ur.Role.RoleName))
                .FirstOrDefaultAsync(); // En caso tenga múltiples roles, toma el primero
        }
        public async Task<User?> GetUserWithRolesAsync(LoginDTO loginDto)
        {
            return await context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u =>
                    u.Email == loginDto.Email &&
                    u.Password == loginDto.Password
                );
        }

    }
}
