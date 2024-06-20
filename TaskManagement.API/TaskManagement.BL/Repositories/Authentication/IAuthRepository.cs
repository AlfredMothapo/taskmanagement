using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BL.Models;

namespace TaskManagement.BL.Repositories.Authentication
{
    public interface IAuthRepository
    {
        Task RegisterAsync(UserModel user);
        Task<UserModel> LoginAsync(string emailAddress, string password);
        Task DeactivateUserAsync(Guid userId);
    }
}
