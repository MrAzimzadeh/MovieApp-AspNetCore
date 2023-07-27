using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Core.Utilities.Security.Hashing;

namespace MovieApp.Entities.DTOs.UserDtos
{
    public class UserRegisterDTO
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public byte[] PasswordSalt { get; private set; }
        //public byte[] PasswordHash { get; private set; }


    }
}
