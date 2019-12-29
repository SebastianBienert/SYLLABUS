using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.UseCases.CreateMinisterialEffect;

namespace PWRSyllabus.Core.UseCases.UpdateMinisterialEffect
{
    public class UpdateMinisterialEffectUseCase
    {
        private ICRUDRepository _crudRepository;
        private IMapper _mapper;

        public UpdateMinisterialEffectUseCase(ICRUDRepository crudRepository, IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<MinisterialEffect> Execute(UpdateMinisterialEffectInput input)
        {
            var discipline = _crudRepository.GetByIdAsync<Discipline>(input.DisciplineId);
            var effect = _mapper.Map<UpdateMinisterialEffectInput, MinisterialEffect>(input);
            effect.FieldOfKnowledgeId = (await discipline).FieldOfKnowledgeId;
            //TODO TEGO TEZ NIE MA NA MOCKUPACH, ma byc?
            await _crudRepository.UpdateAsync(effect);
            return effect;
        }
    }
}
