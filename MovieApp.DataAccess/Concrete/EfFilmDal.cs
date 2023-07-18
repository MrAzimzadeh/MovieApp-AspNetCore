using Microsoft.EntityFrameworkCore;
using Movie.Core.DataAccess.EntityFreamwork;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities.Concrete;
using MovieApp.Entities.DTOs;

namespace MovieApp.DataAccess.Concrete;

public class EfFilmDal : EfRepositoryBase<Film, AppDbContext>, IFilmDal
{
    public List<FilmHomeDTO> GetHomeFilms()
    {
        using var context = new AppDbContext();
        var result = context.Films.Select(x => new FilmHomeDTO
        {
            Id = x.Id,
            Name = x.Name,
            PhotoURL = x.PhotoUrl
        }).ToList();
        return result;
    }

    public FilmDetailDTO GetFilmById(int id)
    {
        using var context = new AppDbContext();

        var result = context.Films.Include(q => q.FilmActors).ThenInclude(s => s.Actor).Select(z => new FilmDetailDTO
        {
            Id = z.Id,
            Name = z.Name,
            CoverUrl = z.CoverUrl,
            Description = z.Description,
            Imdb = z.Imdb,
            PhotoUrl = z.PhotoUrl,
            VIdeoUrl = z.VIdeoUrl,
            View = z.View,
            Actors = z.FilmActors.Select(a => new ActorDTO
            {
                Id = a.ActorId,
                Name = a.Actor.Name,
                PhotoUrl = a.Actor.PhotoUrl,
                Character = a.Actor.Character,
                Surname = a.Actor.Surname,
            }).ToList()
        }).SingleOrDefault(x => x.Id == id);
        return result;
    }
}

