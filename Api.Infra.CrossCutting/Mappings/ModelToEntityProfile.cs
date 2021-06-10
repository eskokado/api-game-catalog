using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<PlayerEntity, PlayerModel>().ReverseMap();
            CreateMap<GameEntity, GameModel>().ReverseMap();
            CreateMap<StarEntity, StarModel>().ReverseMap();
        }
    }
}