using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Core.Utilities.Results.Abstract;
using MovieApp.Entities.DTOs.ActorDTOs;
using MovieApp.Entities.DTOs.UserDtos;

namespace MovieApp.Business.Abstract
{
    public interface IActorService
    {
        IResult AddActor(ActorCreateDTO actorCreateDto);
        IResult UpdateActor(ActorUpdateDTO actorCreateDto);
        IDataResult<List<ActorDTO>>GetActorList();
       
    }
}
