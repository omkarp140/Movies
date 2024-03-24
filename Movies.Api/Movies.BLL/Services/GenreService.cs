using Movies.BLL.Interfaces;
using Movies.Models.DTO.Genre;
using Movies.Models.Generic.Response;
using Movies.Models.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Movies.DAL.Repositories.Genre;
using Movies.DAL.Repositories;

namespace Movies.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;

        public GenreService(IGenreRepository genreRepository,
                               IMapper mapper,
                               ILogger<GenreService> logger) 
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenericResponse<LinkedCollectionResourceWrapperDto<GenreReadDto>>> GetAllGenres()
        {
            _logger.LogInformation("Getting all genres");
            var response = await _genreRepository.SelectAsync(new NoBasicFilter { }, new NoRequestFilter { });
            var result = _mapper.Map<IEnumerable<GenreReadDto>>(response.RecordsFromDb);
            return ResponseHelper.GetPagedResponse(new LinkedCollectionResourceWrapperDto<GenreReadDto>(result), result.Count(), 10);
        }

        public async Task<GenericResponse<GenreReadDto>> GetGenre(int id)
        {
            var response = await _genreRepository.SelectSingleAsync(id);
            var result = _mapper.Map<GenreReadDto>(response);
            return ResponseHelper.GetResponse(result);
        }
    }
}
