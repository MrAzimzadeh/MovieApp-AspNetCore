using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.Entities.Abstract;

namespace MovieApp.Entities.Concrete
{
    public class Genre : BaseEntity, IEntity
    {
        public string Name { get; set; }
        List<FilmGenre> FilmGenre { get; set; }
    }
}
