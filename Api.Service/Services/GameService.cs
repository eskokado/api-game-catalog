using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Game;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GameDtoResult>> FindByName(string name)
        {
            var entities = await _repository.FindByName(name);
            return _mapper.Map<IEnumerable<GameDtoResult>> (entities);
        }

        public async Task<GameDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<GameDtoResult> (entity);
        }

        public async Task<IEnumerable<GameDtoResult>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<GameDtoResult>> (entities);
        }

        public async Task<GameDtoCreateResult> Post(GameDtoCreate dto)
        {
            var model = _mapper.Map<GameModel> (dto);
            var entity = _mapper.Map<GameEntity> (model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<GameDtoCreateResult> (result);
        }

        public async Task<GameDtoUpdateResult> Put(GameDtoUpdate dto)
        {
            var model = _mapper.Map<GameModel> (dto);
            var entity = _mapper.Map<GameEntity> (model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<GameDtoUpdateResult> (result);
        }
    }
}