using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Game;
using Api.Domain.Dtos.Player;
using Api.Domain.Dtos.Star;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Stars
{
    public class WhenToRequestStars : BaseIntegration
    {
        private Guid _gameId { get; set; }
        private Guid _playerId { get; set; }
        private int _starAmount { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunStarsCrud() {
            await AddToken();

            // Find By Name Game
            var responseGame = await client.GetAsync($"{hostApi}/games/findByName/a");
            Assert.Equal(HttpStatusCode.OK, responseGame.StatusCode);

            var jsonResultGame = await responseGame.Content.ReadAsStringAsync();
            var listFromJsonGame = JsonConvert.DeserializeObject<IEnumerable<GameDtoResult>>(jsonResultGame);
            var recordSelectedGame = listFromJsonGame.FirstOrDefault();

            // Find By Name Player
            var responsePlayer = await client.GetAsync($"{hostApi}/players/findByName/user");
            Assert.Equal(HttpStatusCode.OK, responsePlayer.StatusCode);

            var jsonResultPlayer = await responsePlayer.Content.ReadAsStringAsync();
            var listFromJsonPlayer = JsonConvert.DeserializeObject<IEnumerable<PlayerDtoResult>>(jsonResultPlayer);
            var recordSelectedPlayer = listFromJsonPlayer.FirstOrDefault();

            _gameId = recordSelectedGame.Id;
            _playerId = recordSelectedPlayer.Id;
            _starAmount = Faker.RandomNumber.Next(0, 10);

            var starDto = new StarDtoCreate()
            {
                GameId = _gameId,
                PlayerId = _playerId,
                Star = _starAmount,
            };

            // Post
            var response = await PostJsonAsync(starDto, $"{hostApi}/stars", client);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<StarDtoResult>(postResult);

            Assert.Equal(starDto.GameId, recordPost.GameId);
            Assert.Equal(starDto.PlayerId, recordPost.PlayerId);
            Assert.Equal(starDto.Star, recordPost.Star);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/stars");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<StarDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Find By Game Name
            response = await client.GetAsync($"{hostApi}/stars/findByGameName/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<StarDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Find By Player Name
            response = await client.GetAsync($"{hostApi}/stars/findByPlayerName/us");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<StarDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Put
            var updateStarDto = new StarDtoUpdate()
            {
                Id = recordPost.Id,
                GameId = _gameId,
                PlayerId = _playerId,
                Star = _starAmount,
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateStarDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/stars", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<StarDtoResult>(jsonResult);

            Assert.Equal(updateStarDto.Id, recordUpdate.Id);
            Assert.Equal(updateStarDto.GameId, recordUpdate.GameId);
            Assert.Equal(updateStarDto.PlayerId, recordUpdate.PlayerId);
            Assert.Equal(updateStarDto.Star, recordUpdate.Star);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/stars/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<StarDtoResult>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.GameId, recordUpdate.GameId);
            Assert.Equal(recordSelected.PlayerId, recordUpdate.PlayerId);
            Assert.Equal(recordSelected.Star, recordUpdate.Star);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/stars/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/stars/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}