using Movie.Core.DataAccess;
using MovieApp.Entities.Concrete;
using MovieApp.Entities.DTOs;

namespace MovieApp.DataAccess.Abstract;

public interface IFilmDal : IRepositoryBase<Film>
{
    List<FilmHomeDTO> GetHomeFilms();
    FilmDetailDTO GetFilmById(int id);

}