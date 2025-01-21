using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Users.LoginUser
{
    public class LoginUserCommand : ICommand
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
