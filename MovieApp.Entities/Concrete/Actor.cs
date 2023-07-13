using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.Entities.Abstract;

namespace MovieApp.Entities.Concrete
{
    public class Actor: BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Character { get; set; }
        public string PhotoUrl { get; set; }
        public  List<FilmActor> FilmActors { get; set; }
    }
}
