using MovieApp.Business.Abstract;
using MovieApp.DataAccess.Abstract;

namespace MovieApp.Business.Concrete;

public class FilmManager : IFilmServices
{
    private readonly IFilmDal _filmDal;

    public FilmManager(IFilmDal filmDal)
    {
        _filmDal = filmDal;
    }
    
    
    
}