using Microsoft.Extensions.DependencyInjection;
using MovieApp.Business.Abstract;
using MovieApp.Business.Concrete;
using MovieApp.DataAccess.Abstract;

namespace MovieApp.Business.DependencyResolvers.OwnDependency;

public static class DependencyCreater
{
    public static void CreateScoped(this IServiceCollection service)
    {
        service.AddScoped<IFilmServices, FilmManager>();
    }
}