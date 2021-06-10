using Api.Domain.Dtos.Game;
using Api.Domain.Dtos.Player;
using Api.Domain.Dtos.Star;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<PlayerDtoResult, PlayerEntity>().ReverseMap();

            CreateMap<PlayerDtoCreateResult, PlayerEntity>().ReverseMap();

            CreateMap<PlayerDtoUpdateResult, PlayerEntity>().ReverseMap();
            #endregion

            #region Game
            CreateMap<GameDtoResult, GameEntity>().ReverseMap();

            CreateMap<GameDtoCreateResult, GameEntity>().ReverseMap();

            CreateMap<GameDtoUpdateResult, GameEntity>().ReverseMap();
            #endregion

            #region Star
            CreateMap<StarDtoResult, StarEntity>().ReverseMap();
            #endregion
        }
    }
}