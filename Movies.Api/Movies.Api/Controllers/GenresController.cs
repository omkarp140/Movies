using Microsoft.AspNetCore.Mvc;
using Movies.Api.Filters;
using Movies.BLL.Interfaces;
using Movies.Models.DTO.Genre;
using Movies.Models.Generic;
using Movies.Models.Generic.Response;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService inMemoryService)
        {
            _genreService = inMemoryService;
        }

        [UserActivityLogFilter(Module ="Genres", Activity = "GetAllGenres")]
        [ProducesResponseType(typeof(GenericResponse<LinkedCollectionResourceWrapperDto<GenreCreateDto>>), 200)]
        [HttpGet]
        //[ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAllGenres()
        {
            return Ok(await _genreService.GetAllGenres());
        }

        [UserActivityLogFilter(Module = "Genres", Activity = "GetGenre")]
        [ProducesResponseType(typeof(GenericResponse<GenreCreateDto>), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleGenre(int id)
        {
            return Ok(await _genreService.GetGenre(id));

        }

        [UserActivityLogFilter(Module = "Genres", Activity = "CreateGenre")]
        [HttpPost]
        public void Create()
        {

        }

        [UserActivityLogFilter(Module = "Genres", Activity = "UpdateGenre")]
        [HttpPut]
        public async Task<IActionResult> Update() 
        {
            return Ok("success");
        }

        [UserActivityLogFilter(Module = "Genres", Activity = "DeleteGenre")]
        [HttpDelete]
        public async Task<IActionResult> Delete() 
        {
            return Ok("success");
        }
    }
}
