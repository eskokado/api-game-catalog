using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Player;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class PlayerMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos (Player)")]
        public void ItIsPossibleToMapTheModelsPlayer()
        {
            var model = new PlayerModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<PlayerEntity>();
            for (int i = 0; i < 5; i++) {
                var item = new PlayerEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            var dtoCreate = new PlayerDtoCreate
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            var dtoUpdate = new PlayerDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
            };

            var modelToEntity = Mapper.Map<PlayerEntity>(model);
            Assert.Equal(modelToEntity.Id, model.Id);
            Assert.Equal(modelToEntity.Name, model.Name);
            Assert.Equal(modelToEntity.Email, model.Email);
            Assert.Equal(modelToEntity.CreateAt, model.CreateAt);
            Assert.Equal(modelToEntity.UpdateAt, model.UpdateAt);

            var dto = Mapper.Map<PlayerDtoResult>(modelToEntity);
            Assert.Equal(dto.Id, modelToEntity.Id);
            Assert.Equal(dto.Name, modelToEntity.Name);
            Assert.Equal(dto.Email, modelToEntity.Email);
            Assert.Equal(dto.CreateAt, modelToEntity.CreateAt);
            Assert.Equal(dto.UpdateAt, modelToEntity.UpdateAt);

            var listDto = Mapper.Map<List<PlayerDtoResult>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());

            var dtoCreateResult = Mapper.Map<PlayerDtoCreateResult>(modelToEntity);
            Assert.Equal(dtoCreateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoCreateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoCreateResult.Email, modelToEntity.Email);
            Assert.Equal(dtoCreateResult.CreateAt, modelToEntity.CreateAt);

            var dtoUpdateResult = Mapper.Map<PlayerDtoUpdateResult>(modelToEntity);
            Assert.Equal(dtoUpdateResult.Id, modelToEntity.Id);
            Assert.Equal(dtoUpdateResult.Name, modelToEntity.Name);
            Assert.Equal(dtoUpdateResult.Email, modelToEntity.Email);
            Assert.Equal(dtoUpdateResult.UpdateAt, modelToEntity.UpdateAt);
 
            var genModel = Mapper.Map<PlayerModel>(dtoCreate);
            Assert.Equal(genModel.Name, dtoCreate.Name);
            Assert.Equal(genModel.Email, dtoCreate.Email);

            genModel = Mapper.Map<PlayerModel>(dtoUpdate);
            Assert.Equal(genModel.Id, dtoUpdate.Id);
            Assert.Equal(genModel.Name, dtoUpdate.Name);
            Assert.Equal(genModel.Email, dtoUpdate.Email);
        }
    }
}