using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Core.Entities.Concrete;
using Movie.Core.Utilities.Bussiness;
using Movie.Core.Utilities.Security.Hashing.JWT;
using MovieApp.Business.Abstract;
using MovieApp.Business.Constants;
using MovieApp.Core.Utilities.Results.Abstract;
using MovieApp.Core.Utilities.Results.Conrete.ErrorResult;
using MovieApp.Core.Utilities.Results.Conrete.SuccessResult;
using MovieApp.Core.Utilities.Security.Hashing;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities.DTOs.UserDtos;

namespace MovieApp.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _UserDal;
        private readonly IMapper _Mapper;

        public AuthManager(IUserDal userDal, IMapper mapper)
        {
            _UserDal = userDal;
            _Mapper = mapper;
        }

        public IResult Login(UserLoginDTO userLoginDTO)
        {
            var findUser = _UserDal.GetUserWithRole(userLoginDTO.Email);
            var result = BussinessRoles.Check(CheckEmailOrPasswprd(userLoginDTO.Email), VerfilyPassword(findUser, userLoginDTO.Password));
            if (result.Success)
            {
                var role = !findUser.UserRoles.Any() ? "User" : findUser.UserRoles.FirstOrDefault().Role.Name;
                var token = TokenGenerator.Token(findUser, role);
                return new SuccessResult(201, token);
            }
            return new ErrorResult(401);

        }

        public IResult Register(UserRegisterDTO userRegister)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userRegister.Password, out passwordHash, out passwordSalt);
                User newUser = new()
                {
                    FirstName = userRegister.FirstName,
                    LastName = userRegister.LastName,
                    Email = userRegister.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };

                //var mapper = _Mapper.Map<User>(userRegister);
                _UserDal.Add(newUser);
                return new SuccessResult(201, "Succes");
            }
            catch (Exception e)
            {
                return new ErrorResult(400, e.Message);
            }
        }


        private IResult CheckEmailOrPasswprd(string userEmail)
        {
            var findUser = _UserDal.Get(x => x.Email == userEmail);
            if (findUser is null)
            {
                return new ErrorResult(401, Messages.EmailAndPasswordNotCorrect);
            }
            return new SuccessResult(201);
        }

        private IResult VerfilyPassword(User user, string Password)
        {
            var checkPassword = HashingHelper.VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt);
            if (!checkPassword)
            {
                return new ErrorResult(401, Messages.EmailAndPasswordNotCorrect);
            }
            return new SuccessResult(201);
        }
    }
}
