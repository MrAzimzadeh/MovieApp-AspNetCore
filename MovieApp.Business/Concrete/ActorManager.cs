using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieApp.Business.Abstract;
using MovieApp.Core.Utilities.Results.Abstract;
using MovieApp.Core.Utilities.Results.Conrete.ErrorResult;
using MovieApp.Core.Utilities.Results.Conrete.SuccessResult;
using MovieApp.DataAccess.Abstract;
using MovieApp.Entities.Concrete;
using MovieApp.Entities.DTOs.ActorDTOs;

namespace MovieApp.Business.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IActorDal _actorDal;
        private readonly IMapper _mapper;

        public ActorManager(IActorDal actorDal, IMapper mapper)
        {
            _actorDal = actorDal;
            _mapper = mapper;
        }

        public IResult AddActor(ActorCreateDTO actorCreateDto)
        {
            try
            {
                var mapToActor = _mapper.Map<Actor>(actorCreateDto);
                mapToActor.CreatedDate = DateTime.Now;
                mapToActor.IsActive = true;
                _actorDal.Add(mapToActor);
                return new SuccessResult(201);
            }
            catch (Exception e)
            {

                return new ErrorResult(400, e.Message);
            }

        }

        public IResult UpdateActor(ActorUpdateDTO actorCreateDto)
        {
            try
            {
                var updateActor = _mapper.Map<Actor>(actorCreateDto);
                _actorDal.Update(updateActor);
                return new SuccessResult(201);
            }
            catch (Exception e)
            {

                return new ErrorResult(400);
            }

        }

        public IDataResult<List<ActorDTO>> GetActorList()
        {
            try
            {
                var actorLIst = _actorDal.GetAll();
                var mapper = _mapper.Map<List<ActorDTO>>(actorLIst);
                return new SuccessDataResult<List<ActorDTO>>(mapper, 200);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<ActorDTO>>(e.Message, 400);
            }

        }
    }
}
