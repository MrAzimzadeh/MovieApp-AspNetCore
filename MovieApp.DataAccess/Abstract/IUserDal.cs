using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.DataAccess;
using Movie.Core.Entities.Concrete;
using MovieApp.Core.Utilities.Results.Abstract;

namespace MovieApp.DataAccess.Abstract
{
    public interface IUserDal : IRepositoryBase<User>
    {
       User GetUserWithRole(string email);
    }
}
