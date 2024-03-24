using AutoMapper;
using Movies.Models.DTO.Genre;
using Movies.Models.EF.Customer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Movies.BLL.Automapper
{
    public class AutomapperEfProfile : Profile
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public AutomapperEfProfile() 
        {
            MapGenres();
        }

        private void MapGenres()
        {
            CreateMap<Genre, GenreReadDto>();
        }
    }
}
