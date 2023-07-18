using Microsoft.Extensions.DependencyInjection;
using MovieApp.Business.Abstract;
using MovieApp.Business.Concrete;
using MovieApp.DataAccess.Abstract;
using MovieApp.DataAccess.Concrete;
using MovieApp.DataAccess.DataSeeding.Abstract;
using MovieApp.DataAccess.DataSeeding.Concrete;

namespace MovieApp.Business.DependencyResolvers.OwnDependency;

public static class DependencyCreater
{
    public static void CreateScoped(this IServiceCollection service)
    {
        service.AddScoped<AppDbContext>();

        service.AddScoped<IFilmServices, FilmManager>();
        service.AddScoped<IFilmDal, EfFilmDal>();
        service.AddSingleton<IDataSeeder, EfDataSeeder>();
    }
}