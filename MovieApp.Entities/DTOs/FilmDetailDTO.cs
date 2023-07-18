using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Entities.Concrete;

namespace MovieApp.Entities.DTOs
{
    public class FilmDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string VIdeoUrl { get; set; }
        public string CoverUrl { get; set; }
        public int Imdb { get; set; }
        public int View { get; set; }
        public List<ActorDTO> Actors { get; set; }
    }
}
