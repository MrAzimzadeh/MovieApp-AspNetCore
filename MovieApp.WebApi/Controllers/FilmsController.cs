using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;

namespace MovieApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmServices _filmServices;

        public FilmsController(IFilmServices filmServices)
        {
            _filmServices = filmServices;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            return Ok(_filmServices.GetHomePagesFilms());
        }


        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var film = _filmServices.GetFilmById(id);
                return Ok(film);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //  
            }
        }




    }
}
