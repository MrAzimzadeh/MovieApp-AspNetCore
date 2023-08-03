using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Core.Entities.Concrete;
using Movie.Core.Utilities.Security.Hashing.JWT;
using MovieApp.Business.Abstract;
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
            var findUser = _UserDal.Get(x => x.Email == userLoginDTO.Email);
            if (findUser is null)
            {
                return new ErrorResult(401, "Password or Email is Not correct ");
            }
            var checkPassword = HashingHelper.VerifyPasswordHash(userLoginDTO.Password, findUser.PasswordHash, findUser.PasswordSalt);
            if (!checkPassword)
            {
                return new ErrorResult(401, "Password or Email is Not correct ");
            }
            var token = TokenGenerator.Token(findUser, "Admin");
            
            return new SuccessResult(201, token);

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
                    PasswordSalt = passwordSalt
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
    }
}
