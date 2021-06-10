using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Player;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PlayerDtoResult>> FindByName(string name)
        {
            var entities = await _repository.FindByName(name);
            return _mapper.Map<IEnumerable<PlayerDtoResult>> (entities);
        }

        public async Task<PlayerDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PlayerDtoResult> (entity);
        }

        public async Task<IEnumerable<PlayerDtoResult>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PlayerDtoResult>> (entities);
        }

        public async Task<PlayerDtoCreateResult> Post(PlayerDtoCreate dto)
        {
            var model = _mapper.Map<PlayerModel> (dto);
            var entity = _mapper.Map<PlayerEntity> (model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PlayerDtoCreateResult> (result);
        }

        public async Task<PlayerDtoUpdateResult> Put(PlayerDtoUpdate dto)
        {
            var model = _mapper.Map<PlayerModel> (dto);
            var entity = _mapper.Map<PlayerEntity> (model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<PlayerDtoUpdateResult> (result);
        }
    }
}