using Movie.Core.DataAccess.EntityFreamwork;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.Concrete;

public class EfFilmDal : EfRepositoryBase<Film, AppDbContext>, IFilmDal
{ 
        
}

