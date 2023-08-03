using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Core.DataAccess.EntityFreamwork;
using Movie.Core.Entities.Concrete;
using MovieApp.DataAccess.Abstract;

namespace MovieApp.DataAccess.Concrete
{
    public class EfUserDal : EfRepositoryBase<User, AppDbContext>, IUserDal
    {
        public User GetUserWithRole(string email)
        {
            using var context = new AppDbContext();

            var result = context.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).SingleOrDefault(x => x.Email == email);
            return result;
        }
    }
}
