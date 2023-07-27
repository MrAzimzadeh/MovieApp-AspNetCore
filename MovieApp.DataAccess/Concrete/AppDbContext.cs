using Microsoft.EntityFrameworkCore;
using Movie.Core.Entities.Concrete;
using MovieApp.Core.Entities.Concrete;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.Concrete;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=127.0.0.1,1433;Database=MovieAppDb; User Id=sa; Password=Password@12345; TrustServerCertificate=True;");
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<FilmActor> FilmActors { get; set; }
    public DbSet<FilmGenre> FilmGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }


}