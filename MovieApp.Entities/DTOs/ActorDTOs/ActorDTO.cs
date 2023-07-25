using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities.DTOs.ActorDTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Character { get; set; }
        public string PhotoUrl { get; set; }
    }
}
