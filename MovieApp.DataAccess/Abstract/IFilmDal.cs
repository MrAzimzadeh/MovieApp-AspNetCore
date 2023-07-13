using Movie.Core.DataAccess;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.Abstract;

public interface IFilmDal : IRepositoryBase<Film>
{
    
}