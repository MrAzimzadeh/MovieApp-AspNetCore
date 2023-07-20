using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Core.Entities.Abstract;

namespace MovieApp.Entities.Concrete
{
    public class Category :  BaseEntity , IEntity
    {
        public string CategoryName { get; set; }
        

    }
}
