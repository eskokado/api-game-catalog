using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Player;

namespace Api.Service.Test.Player
{
    public class PlayerTest
    {
        public string PlayerName { get; set; }
        public string PlayerEmail { get; set; }
        public string PlayerNameUpdate { get; set; }
        public string PlayerEmailUpdate { get; set; }
        public Guid PlayerId { get; set; }

        public List<PlayerDtoResult> listPlayerDto = new List<PlayerDtoResult>();

        public PlayerDtoResult playerDtoResult = new PlayerDtoResult();
        public PlayerDtoCreate playerDtoCreate;
        public PlayerDtoCreateResult playerDtoCreateResult;
        public PlayerDtoUpdate playerDtoUpdate;
        public PlayerDtoUpdateResult playerDtoUpdateResult;

        public PlayerTest()
        {
            PlayerId = Guid.NewGuid();
            PlayerName = Faker.Name.FullName();
            PlayerEmail = Faker.Internet.Email();
            PlayerNameUpdate = Faker.Name.FullName();
            PlayerEmailUpdate = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var result = new PlayerDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listPlayerDto.Add(result);
            }

            playerDtoResult = new PlayerDtoResult() 
            {
                Id = PlayerId,
                Name = PlayerName,
                Email = PlayerEmail,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            playerDtoCreate = new PlayerDtoCreate()
            {
                Name = PlayerName,
                Email = PlayerEmail
            };

            playerDtoCreateResult = new PlayerDtoCreateResult()
            {
                Id = PlayerId,
                Name = PlayerName,
                Email = PlayerEmail,
                CreateAt = DateTime.UtcNow
            };

            playerDtoUpdate = new PlayerDtoUpdate()
            {
                Id = PlayerId,
                Name = PlayerNameUpdate,
                Email = PlayerEmailUpdate
            };

            playerDtoUpdateResult = new PlayerDtoUpdateResult()
            {
                Id = PlayerId,
                Name = PlayerNameUpdate,
                Email = PlayerEmailUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}