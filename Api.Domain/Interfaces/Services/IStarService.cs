using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Star;

namespace Api.Domain.Interfaces.Services
{
    public interface IStarService
    {
        Task<StarDtoResult> Get (Guid id);
        Task<IEnumerable<StarDtoResult>> GetAll();
        Task<StarDtoResult> Post(StarDtoCreate dto);
        Task<StarDtoResult> Put(StarDtoUpdate dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<StarDtoResult>> FindCompleteByPlayerName(string name);
        Task<IEnumerable<StarDtoResult>> FindCompleteByGameName(string name);
        Task<IEnumerable<StarDtoResult>> FindBiggestStar(int amount);
    }
}