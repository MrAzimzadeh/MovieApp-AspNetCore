using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.DataAccess.EntityFreamwork;
using Movie.Core.Entities.Concrete;
using MovieApp.DataAccess.Abstract;

namespace MovieApp.DataAccess.Concrete
{
    public class EfUserDal :  EfRepositoryBase<User , AppDbContext> , IUserDal 
    {
    }
}
