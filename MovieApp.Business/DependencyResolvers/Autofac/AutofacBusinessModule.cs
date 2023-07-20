using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MovieApp.Business.Abstract;
using MovieApp.Business.Concrete;
using MovieApp.DataAccess.Abstract;
using MovieApp.DataAccess.Concrete;
using MovieApp.DataAccess.DataSeeding.Abstract;
using MovieApp.DataAccess.DataSeeding.Concrete;

namespace MovieApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);
            builder.RegisterType<AppDbContext>();
            builder.RegisterType<EfDataSeeder>().As<IDataSeeder>();

            builder.RegisterType<EfFilmDal>().As<IFilmDal>();
            builder.RegisterType<FilmManager>().As<IFilmServices>();
        }
    }
}
