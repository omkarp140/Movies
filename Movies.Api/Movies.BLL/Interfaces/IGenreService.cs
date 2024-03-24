using Movies.Models.DTO.Genre;
using Movies.Models.Generic;
using Movies.Models.Generic.Response;

namespace Movies.BLL.Interfaces
{
    public interface IGenreService
    {
        Task<GenericResponse<LinkedCollectionResourceWrapperDto<GenreReadDto>>> GetAllGenres();

        Task<GenericResponse<GenreReadDto>> GetGenre(int id);
    }
}
