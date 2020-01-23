using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PWRSyllabus.Core;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Interfaces;
using PWRSyllabus.Core.UseCases.CreateMinisterialEffect;
using PWRSyllabus.Core.UseCases.UpdateMinisterialEffect;
using PWRSyllabusAPI.DTOs;

namespace PWRSyllabusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinisterialEffectController : ControllerBase
    {
        private readonly IMinisterialEffectRepository _repository;
        private readonly ICRUDRepository _crudRepository;
        private readonly IMapper _mapper;
        private readonly CreateMinisterialEffectUseCase _createEffect;
        private readonly UpdateMinisterialEffectUseCase _updateEffect;

        public MinisterialEffectController(IMinisterialEffectRepository repository, IMapper mapper, CreateMinisterialEffectUseCase createEffect, UpdateMinisterialEffectUseCase updateEffect, ICRUDRepository crudRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _createEffect = createEffect;
            _updateEffect = updateEffect;
            _crudRepository = crudRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMinisterialEffects()
        {
            var minsiterialEffects = await _repository.GetAllMinisterialEffects();
            var ministerialEffectDtos = minsiterialEffects.Select(d => _mapper.Map<MinisterialEffect, MinisterialEffectDTO>(d));

            return Ok(ministerialEffectDtos);
        }

        [HttpGet("{id}", Name = "GetMinisterialEffectById")]
        public async Task<IActionResult> GetMinisterialEffectDetails(int id)
        {
            var minsiterialEffect = await _repository.GetMinisterialEffect(id);
            var ministerialEffectDto = _mapper.Map<MinisterialEffect, MinisterialEffectDTO>(minsiterialEffect);

            return Ok(ministerialEffectDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMinisterialEffect([FromRoute] int id, [FromBody]MinisterialEffectDTO ministerialEffectDto)
        {
            var updateEffectInput = _mapper.Map<MinisterialEffectDTO, UpdateMinisterialEffectInput>(ministerialEffectDto);
            var editedEffect = await _updateEffect.Execute(updateEffectInput);
            return Ok(editedEffect);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinisterialEffect(int id)
        {
            await _crudRepository.DeleteAsync<MinisterialEffect>(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMinisterialEffect(MinisterialEffectDTO ministerialEffectDto)
        {
            var createEffectInput = _mapper.Map<MinisterialEffectDTO, CreateMinisterialEffectInput>(ministerialEffectDto);
            var addedEffect = await _createEffect.Execute(createEffectInput);
            return CreatedAtRoute("GetMinisterialEffectById", new {id = addedEffect.Id});
        }
    }
}