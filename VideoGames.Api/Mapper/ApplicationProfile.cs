using AutoMapper;
using VideoGames.Api.Models.Abstract;
using VideoGames.Api.Models.Models;
using VideoGames.BLL.Domain.Abstract;
using VideoGames.BLL.Domain.DTO;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.Api.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<GameRequest, GameRequestDTO>().ReverseMap();
            CreateMap<GenreRequest, GenreRequestDTO>().ReverseMap();
            CreateMap<CreaterRequest, CreaterRequestDTO>().ReverseMap();
            CreateMap<GameResponse, GameResponseDTO>().ReverseMap();
            CreateMap<GenreResponse, GenreResponseDTO>().ReverseMap();
            CreateMap<CreaterResponse, CreaterResponseDTO>().ReverseMap();

            CreateMap<GameResponseDTO, GameEntity>().ReverseMap();
            CreateMap<GenreResponseDTO, GenreEntity>().ReverseMap();
            CreateMap<CreaterResponseDTO, CreaterEntity>().ReverseMap();
            
            CreateMap<GameUpdateRequest, GameRequestDTO>().ReverseMap();
        }
    }
}
