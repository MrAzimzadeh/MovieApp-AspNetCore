using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.DataAccess.EntityFreamwork;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.Concrete
{
    public class EfActorDal : EfRepositoryBase<Actor , AppDbContext> ,  IActorDal
    {

    }
}
