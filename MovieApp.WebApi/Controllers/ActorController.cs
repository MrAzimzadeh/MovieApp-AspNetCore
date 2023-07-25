using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;
using MovieApp.Entities.DTOs.ActorDTOs;

namespace MovieApp.WebApi.Controllers
{
    [Route("api/[controller]")]

    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("getall")]
        public IActionResult GetActors()
        {
            try
            {
                var actors = _actorService.GetActorList();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("add")]
        public IActionResult AddActors([FromBody] ActorCreateDTO actorCreateDto)
        {
            var result = _actorService.AddActor(actorCreateDto);
            return Ok(result);
        }


        [HttpPut("update")]
        public IActionResult UpdateActors([FromBody] ActorUpdateDTO actorUpdateDto)
        {
            var result = _actorService.UpdateActor(actorUpdateDto);
            return Ok(result);
        }


    }
}
