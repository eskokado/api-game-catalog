using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Star;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class StarMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (Star)")]
        public void ItIsPossibleToMapTheModelsStar()
        {
            var model = new StarModel
            {
                Id = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var entity = new StarEntity
            {
                Id = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Game = new GameEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                },
                Player = new PlayerEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                }
            };


            var listEntity = new List<StarEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new StarEntity
                {
                    Id = Guid.NewGuid(),
                    GameId = Guid.NewGuid(),
                    PlayerId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Game = new GameEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                    },
                    Player = new PlayerEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                    }
                };
                listEntity.Add(item);
            }

            var dtoCreate = new StarDtoCreate
            {
                GameId = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
            };

            var dtoUpdate = new StarDtoUpdate
            {
                Id = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                PlayerId = Guid.NewGuid(),
            };

            var modelToEntity = Mapper.Map<StarEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.GameId, model.GameId);
            Assert.Equal(modelToEntity.PlayerId, model.PlayerId);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<StarDtoResult>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.GameId, entity.GameId);
            Assert.Equal(dto.PlayerId, entity.PlayerId);
            Assert.Equal(dto.CreateAt, entity.CreateAt);
            Assert.Equal(dto.UpdateAt, entity.UpdateAt);

            var listDto = Mapper.Map<List<StarDtoResult>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());
 
            var genModel = Mapper.Map<StarModel>(dtoCreate);
            Assert.Equal(genModel.GameId, dtoCreate.GameId);
            Assert.Equal(genModel.PlayerId, dtoCreate.PlayerId);

            genModel = Mapper.Map<StarModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.GameId, dtoUpdate.GameId);
            Assert.Equal(genModel.PlayerId, dtoUpdate.PlayerId);
        }
    }
}