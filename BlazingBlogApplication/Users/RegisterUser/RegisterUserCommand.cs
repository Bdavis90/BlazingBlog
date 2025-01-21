using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Users.RegisterUser
{
    public class RegisterUserCommand : ICommand
    {
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string Password{ get; set; }
    }
}
