using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.DTO
{
    public class UserRequestDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordConfirmed { get; set; }
    }
}
