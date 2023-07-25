using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using MovieApp.DataAccess.Concrete;
using MovieApp.DataAccess.DataSeeding.Abstract;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.DataSeeding.Concrete
{
    public class EfDataSeeder : IDataSeeder
    {
        public void AddData()
        {
            using var context = new AppDbContext();

            List<Category> categories = new();
            if (!context.Categories.Any())
            {
                categories.Add(new Category { CategoryName = "Movie", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                categories.Add(new Category { CategoryName = "Series", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }


            List<Actor> actors = new();


            //bogusData.RuleFor(x =>x.Name , )

            if (!context.Actors.Any())
            {
                var bogusData = new Faker<Actor>("az");

                // BOGUS DATA 
                bogusData.RuleFor(x => x.Name, f => f.Name.FindName());
                bogusData.RuleFor(x => x.Surname, f => f.Name.LastName());
                bogusData.RuleFor(x => x.PhotoUrl, f => f.Internet.Avatar());
                bogusData.RuleFor(x => x.Character, f => f.Internet.UserName());
                bogusData.RuleFor(x => x.CreatedDate, f => f.Date.Recent());

                var d = bogusData.Generate(10);
                context.Actors.AddRange(d);
                context.SaveChanges();

            }

            List<Film> films = new();

            if (!context.Films.Any())
            {
                films.Add(new Film { Name = "Film1", Description = "Description1", PhotoUrl = "PhotoUrl1", VIdeoUrl = "VideoUrl1", CoverUrl = "CoverUrl1", Imdb = 8, View = 100, CategoryId = categories[0].Id });
                films.Add(new Film { Name = "Film2", Description = "Description2", PhotoUrl = "PhotoUrl2", VIdeoUrl = "VideoUrl2", CoverUrl = "CoverUrl2", Imdb = 7, View = 200, CategoryId = categories[1].Id });
                films.Add(new Film { Name = "Film3", Description = "Description3", PhotoUrl = "PhotoUrl3", VIdeoUrl = "VideoUrl3", CoverUrl = "CoverUrl3", Imdb = 6, View = 300, CategoryId = categories[0].Id });
                films.Add(new Film { Name = "Film4", Description = "Description4", PhotoUrl = "PhotoUrl4", VIdeoUrl = "VideoUrl4", CoverUrl = "CoverUrl4", Imdb = 9, View = 400, CategoryId = categories[1].Id });
                films.Add(new Film { Name = "Film5", Description = "Description5", PhotoUrl = "PhotoUrl5", VIdeoUrl = "VideoUrl5", CoverUrl = "CoverUrl5", Imdb = 8, View = 500, CategoryId = categories[0].Id });
                films.Add(new Film { Name = "Film6", Description = "Description6", PhotoUrl = "PhotoUrl6", VIdeoUrl = "VideoUrl6", CoverUrl = "CoverUrl6", Imdb = 7, View = 600, CategoryId = categories[0].Id });
                films.Add(new Film { Name = "Film7", Description = "Description7", PhotoUrl = "PhotoUrl7", VIdeoUrl = "VideoUrl7", CoverUrl = "CoverUrl7", Imdb = 9, View = 700, CategoryId = categories[1].Id });
                context.Films.AddRange(films);
                context.SaveChanges();
            }


            if (!context.FilmActors.Any())
            {
                List<FilmActor> filmActors = new();
                filmActors.Add(new FilmActor { ActorId = actors[0].Id, FIlmId = films[0].Id });
                filmActors.Add(new FilmActor { ActorId = actors[0].Id, FIlmId = films[1].Id });
                filmActors.Add(new FilmActor { ActorId = actors[0].Id, FIlmId = films[2].Id });
                filmActors.Add(new FilmActor { ActorId = actors[3].Id, FIlmId = films[2].Id });
                filmActors.Add(new FilmActor { ActorId = actors[1].Id, FIlmId = films[4].Id });
                filmActors.Add(new FilmActor { ActorId = actors[1].Id, FIlmId = films[1].Id });

                context.FilmActors.AddRange(filmActors);
                context.SaveChanges();
            }

            List<Genre> genreList = new();


            if (!context.Genres.Any())
            {
                genreList.Add(new Genre { Name = "Action film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Adventure film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Animated film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Comedy film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Drama", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Fantasy film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Historical film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Horror film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Musical film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Noir film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Romance film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Science fiction film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Thriller film", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                genreList.Add(new Genre { Name = "Western", IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });

                context.Genres.AddRange(genreList);
                context.SaveChanges();
            }

            if (!context.FilmGenres.Any())
            {
                List<FilmGenre> filmGenres = new();
                filmGenres.Add(new FilmGenre { FilmId = films[0].Id, GenreId = genreList[0].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[1].Id, GenreId = genreList[2].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[0].Id, GenreId = genreList[1].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[3].Id, GenreId = genreList[2].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[4].Id, GenreId = genreList[9].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[1].Id, GenreId = genreList[10].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[2].Id, GenreId = genreList[4].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[4].Id, GenreId = genreList[5].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[1].Id, GenreId = genreList[9].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[3].Id, GenreId = genreList[6].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[1].Id, GenreId = genreList[7].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });
                filmGenres.Add(new FilmGenre { FilmId = films[0].Id, GenreId = genreList[9].Id, IsActive = true, IsDeleted = false, CreatedDate = DateTime.Now });


                context.FilmGenres.AddRange(filmGenres);
                context.SaveChanges();
            }

        }
    }
}
