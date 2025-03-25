using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string username);
        Task<User> GetUserByIdAsynch(int id);
        Task AddUserAsync(User user);
    }
}
