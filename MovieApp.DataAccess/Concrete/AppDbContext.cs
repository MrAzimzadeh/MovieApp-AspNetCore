using Microsoft.EntityFrameworkCore;
using MovieApp.Entities.Concrete;

namespace MovieApp.DataAccess.Concrete;

public class AppDbContext :  DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=127.0.0.1,1433;Database=MovieAppDb; User Id=sa; Password=Password@12345; TrustServerCertificate=True;");
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<FilmActor> FilmActors { get; set; }



}