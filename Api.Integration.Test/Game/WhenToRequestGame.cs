using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Game;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Game
{
    public class WhenToRequestGame : BaseIntegration
    {
        private string _name { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunGameCrud() {
            await AddToken();
            _name = Faker.Name.FullName();

            var gameDto = new GameDtoCreate()
            {
                Name = _name,
            };

            // Post
            var response = await PostJsonAsync(gameDto, $"{hostApi}/games", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<GameDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, recordPost.Name);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/games");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<GameDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Find By Name
            response = await client.GetAsync($"{hostApi}/games/findByName/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<GameDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // Put
            var updateGameDto = new GameDtoUpdate()
            {
                Id = recordPost.Id,
                Name = Faker.Name.FullName(),
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateGameDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/games", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<GameDtoUpdateResult>(jsonResult);

            Assert.Equal(updateGameDto.Id, recordUpdate.Id);
            Assert.NotEqual(recordPost.Name, recordUpdate.Name);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/games/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<GameDtoResult>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/games/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/games/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}