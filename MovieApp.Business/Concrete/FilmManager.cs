using MovieApp.Business.Abstract;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities.DTOs;

namespace MovieApp.Business.Concrete;

public class FilmManager : IFilmServices
{
    private readonly IFilmDal _filmDal;

    public FilmManager(IFilmDal filmDal)
    {
        _filmDal = filmDal;
    }


    public IEnumerable<FilmHomeDTO> GetHomePagesFilms()
    {
        return _filmDal.GetHomeFilms();

    }

    public FilmDetailDTO GetFilmById(int id)
    {
        var result = _filmDal.GetFilmById(id);
        return result;
    }
}