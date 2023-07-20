using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.Entities.Abstract;

namespace MovieApp.Entities.Concrete
{
    public class FilmGenre : BaseEntity, IEntity
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
