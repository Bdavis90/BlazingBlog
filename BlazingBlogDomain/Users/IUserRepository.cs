using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogDomain.Users
{
    public interface IUserRepository
    {
        Task<IUser?> GetUserByIdAsync(string userId);
    }
}
