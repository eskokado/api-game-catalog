using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Player;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Player
{
    public class WhenToRequestPlayer : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunPlayerCrud() {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var playerDto = new PlayerDtoCreate()
            {
                Name = _name,
                Email = _email
            };

            // Post
            var response = await PostJsonAsync(playerDto, $"{hostApi}/players", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<PlayerDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, recordPost.Name);
            Assert.Equal(_email, recordPost.Email);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/players");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<PlayerDtoResult>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Put
            var updatePlayerDto = new PlayerDtoUpdate()
            {
                Id = recordPost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updatePlayerDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/players", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<PlayerDtoUpdateResult>(jsonResult);

            Assert.Equal(updatePlayerDto.Id, recordUpdate.Id);
            Assert.NotEqual(recordPost.Name, recordUpdate.Name);
            Assert.NotEqual(recordPost.Email, recordUpdate.Email);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/players/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<PlayerDtoResult>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);
            Assert.Equal(recordSelected.Email, recordUpdate.Email);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/players/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/players/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}