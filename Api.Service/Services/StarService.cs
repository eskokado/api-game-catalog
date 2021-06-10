using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Star;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class StarService : IStarService
    {
        private readonly IStarRepository _repository;
        private readonly IMapper _mapper;
        public StarService(IStarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StarDtoResult>> FindBiggestStar(int amount)
        {
            var entities = await _repository.FindBiggestStar(amount);
            return _mapper.Map<IEnumerable<StarDtoResult>> (entities);
        }

        public async Task<IEnumerable<StarDtoResult>> FindCompleteByGameName(string name)
        {
            var entities = await _repository.FindCompleteByGameName(name);
            return _mapper.Map<IEnumerable<StarDtoResult>> (entities);
        }

        public async Task<IEnumerable<StarDtoResult>> FindCompleteByPlayerName(string name)
        {
            var entities = await _repository.FindCompleteByPlayerName(name);
            return _mapper.Map<IEnumerable<StarDtoResult>> (entities);
        }

        public async Task<StarDtoResult> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<StarDtoResult> (entity);
        }

        public async Task<IEnumerable<StarDtoResult>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<StarDtoResult>> (entities);
        }

        public async Task<StarDtoResult> Post(StarDtoCreate dto)
        {
            var model = _mapper.Map<StarModel> (dto);
            var entity = _mapper.Map<StarEntity> (model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<StarDtoResult> (result);
        }

        public async Task<StarDtoResult> Put(StarDtoUpdate dto)
        {
            var model = _mapper.Map<StarModel> (dto);
            var entity = _mapper.Map<StarEntity> (model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<StarDtoResult> (result);
        }
    }
}