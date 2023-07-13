using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.Entities.Abstract;

namespace MovieApp.Entities.Concrete
{
    public class Film : BaseEntity, IEntity
    {
        public string  Name { get; set; }
        public string  Description { get; set; }
        public string  PhotoUrl { get; set; }
        public string  VIdeoUrl { get; set; }
        public string  CoverUrl { get; set; }
        public int Imdb { get; set; }
        public int View { get; set; }
        public List<FilmActor> FilmActors { get; set; }

    }
}
