using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.DataAccess;
using Movie.Core.DataAccess.EntityFreamwork;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.Abstract
{
    public interface IActorDal :  IRepositoryBase<Actor>
    {
    }
}
