using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Game;

namespace Api.Domain.Interfaces.Services
{
    public interface IGameService
    {
        Task<GameDtoResult> Get (Guid id);
        Task<IEnumerable<GameDtoResult>> GetAll();
        Task<GameDtoCreateResult> Post(GameDtoCreate dto);
        Task<GameDtoUpdateResult> Put(GameDtoUpdate dto);
        Task<bool> Delete(Guid id);          
        Task<IEnumerable<GameDtoResult>> FindByName(string name);
    }
}