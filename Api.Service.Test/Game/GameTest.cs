using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Game;

namespace Api.Service.Test.Game
{
    public class GameTest
    {
        public string GameName { get; set; }
        public string GameNameUpdate { get; set; }
        public Guid GameId { get; set; }

        public List<GameDtoResult> listGameDto = new List<GameDtoResult>();

        public GameDtoResult gameDtoResult = new GameDtoResult();
        public GameDtoCreate gameDtoCreate;
        public GameDtoCreateResult gameDtoCreateResult;
        public GameDtoUpdate gameDtoUpdate;
        public GameDtoUpdateResult gameDtoUpdateResult;

        public GameTest()
        {
            GameId = Guid.NewGuid();
            GameName = Faker.Name.FullName();
            GameNameUpdate = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {
                var result = new GameDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listGameDto.Add(result);
            }

            gameDtoResult = new GameDtoResult() 
            {
                Id = GameId,
                Name = GameName,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            gameDtoCreate = new GameDtoCreate()
            {
                Name = GameName,
            };

            gameDtoCreateResult = new GameDtoCreateResult()
            {
                Id = GameId,
                Name = GameName,
                CreateAt = DateTime.UtcNow
            };

            gameDtoUpdate = new GameDtoUpdate()
            {
                Id = GameId,
                Name = GameNameUpdate,
            };

            gameDtoUpdateResult = new GameDtoUpdateResult()
            {
                Id = GameId,
                Name = GameNameUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}