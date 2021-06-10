using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Game;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class GameMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (Game)")]
        public void ItIsPossibleToMapTheModelsGame()
        {
            var model = new GameModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<GameEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new GameEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            var dtoCreate = new GameDtoCreate
            {
                Name = Faker.Name.FullName(),
            };

            var dtoUpdate = new GameDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
            };

            var modelToEntity = Mapper.Map<GameEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<GameDtoResult>(modelToEntity);
            Assert.Equal(dto.Id, modelToEntity.Id);
            Assert.Equal(dto.Name, modelToEntity.Name);
            Assert.Equal(dto.CreateAt, modelToEntity.CreateAt);
            Assert.Equal(dto.UpdateAt, modelToEntity.UpdateAt);

            var listDto = Mapper.Map<List<GameDtoResult>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dtoCreateResult = Mapper.Map<GameDtoCreateResult>(modelToEntity);
            Assert.Equal(dtoCreateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoCreateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoCreateResult.CreateAt, modelToEntity.CreateAt);

            var dtoUpdateResult = Mapper.Map<GameDtoUpdateResult>(modelToEntity);
            Assert.Equal(dtoUpdateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoUpdateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoUpdateResult.UpdateAt, modelToEntity.UpdateAt);
 
            var genModel = Mapper.Map<GameModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);

            genModel = Mapper.Map<GameModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);
        }
    }
}