using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Player;

namespace Api.Domain.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<PlayerDtoResult> Get (Guid id);
        Task<IEnumerable<PlayerDtoResult>> GetAll();
        Task<PlayerDtoCreateResult> Post(PlayerDtoCreate dto);
        Task<PlayerDtoUpdateResult> Put(PlayerDtoUpdate dto);
        Task<bool> Delete(Guid id);          
        Task<IEnumerable<PlayerDtoResult>> FindByName(string name);

    }
}