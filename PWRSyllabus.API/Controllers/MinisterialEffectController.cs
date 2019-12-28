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
using PWRSyllabusAPI.DTOs;

namespace PWRSyllabusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinisterialEffectController : ControllerBase
    {
        private readonly IMinisterialEffectRepository _repository;
        private readonly IMapper _mapper;
        public MinisterialEffectController(IMinisterialEffectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinisterialEffect(int id)
        {
            await _repository.DeleteMinisterialEffect(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMinisterialEffecct(MinisterialEffectDTO ministerialEffectDto)
        {
            var ministerialEffect = _mapper.Map<MinisterialEffectDTO, MinisterialEffect>(ministerialEffectDto);
            var addedEffect = await _repository.CreateMinisterialEffect(ministerialEffect);

            return CreatedAtRoute("GetMinisterialEffectById", new {id = addedEffect.Id});
        }



    }
}