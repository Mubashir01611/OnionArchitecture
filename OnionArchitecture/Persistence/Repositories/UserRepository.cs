using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsynch(int id)
        {
            var user =  await _context.Users.FindAsync(id);
            return user;
        }

        public Task<bool> UserExists(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
