using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Star;

namespace Api.Service.Test.Star
{
    public class StarTest
    {
        public Guid StarPlayerId { get; set; }
        public Guid StarGameId { get; set; }
        public Guid StarId { get; set; }
        public int StarAmount { get; set; }

        public List<StarDtoResult> listStarDto = new List<StarDtoResult>();

        public StarDtoResult starDtoResult = new StarDtoResult();
        public StarDtoCreate starDtoCreate;
        public StarDtoUpdate starDtoUpdate;

        public StarTest()
        {
            StarId = Guid.NewGuid();
            StarPlayerId = Guid.NewGuid();
            StarGameId = Guid.NewGuid();
            StarAmount = Faker.RandomNumber.Next(0, 10);

            for (int i = 0; i < 10; i++)
            {
                var result = new StarDtoResult()
                {
                    Id = Guid.NewGuid(),
                    GameId = Guid.NewGuid(),
                    PlayerId = Guid.NewGuid(),
                    Star = Faker.RandomNumber.Next(0, 10),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listStarDto.Add(result);
            }

            starDtoResult = new StarDtoResult() 
            {
                Id = StarId,
                PlayerId = StarPlayerId,
                GameId = StarGameId,
                Star = StarAmount,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            starDtoCreate = new StarDtoCreate()
            {
                PlayerId = StarPlayerId,
                GameId = StarGameId,
                Star = StarAmount
            };


            starDtoUpdate = new StarDtoUpdate()
            {
                Id = StarId,
                PlayerId = StarPlayerId,
                GameId = StarGameId,
                Star = StarAmount
            };
        }
    }
}