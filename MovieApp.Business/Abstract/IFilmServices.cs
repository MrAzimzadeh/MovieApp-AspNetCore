using MovieApp.Entities.DTOs;

namespace MovieApp.Business.Abstract;

public interface IFilmServices
{
    IEnumerable<FilmHomeDTO> GetHomePagesFilms();
    FilmDetailDTO GetFilmById(int id);
}