using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Core.Utilities.Results.Abstract;
using MovieApp.Entities.DTOs.UserDtos;

namespace MovieApp.Business.Abstract
{
    public interface IAuthService
    {
        IResult Login(UserLoginDTO userLogin);
        IResult Register(UserRegisterDTO userRegister);
    }
}
