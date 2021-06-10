using Api.Domain.Dtos.Game;
using Api.Domain.Dtos.Player;
using Api.Domain.Dtos.Star;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<PlayerModel, PlayerDtoCreate>()
                .ReverseMap();
            CreateMap<PlayerModel, PlayerDtoUpdate>()
                .ReverseMap();
            CreateMap<GameModel, GameDtoCreate>()
                .ReverseMap();
            CreateMap<GameModel, GameDtoUpdate>()
                .ReverseMap();
            CreateMap<StarModel, StarDtoCreate>()
                .ReverseMap();
            CreateMap<StarModel, StarDtoUpdate>()
                .ReverseMap();
        }
    }
}