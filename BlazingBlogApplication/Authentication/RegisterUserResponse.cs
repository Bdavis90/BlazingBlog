using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Authentication
{
    public class RegisterUserResponse
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
