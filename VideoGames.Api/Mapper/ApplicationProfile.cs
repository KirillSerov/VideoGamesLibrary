using AutoMapper;
using VideoGames.Api.Models.Models;
using VideoGames.BLL.Domain.DTO;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.Api.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<GameDTO, GameEntity>().ReverseMap();
            CreateMap<GenreDTO, GenreEntity>().ReverseMap();
            CreateMap<CreaterDTO, CreaterEntity>().ReverseMap();
           
            CreateMap<GameDTO, GameModel>().ReverseMap();
            CreateMap<GenreDTO, GenreModel>().ReverseMap();
            CreateMap<CreaterDTO, CreaterModel>().ReverseMap();

        }
    }
}
