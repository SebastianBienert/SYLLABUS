using System.Threading.Tasks;
using AutoMapper;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;
using Profile = PWRSyllabus.Core.Enums.Profile;

namespace PWRSyllabus.Core.UseCases.CreateMinisterialEffect
{
    public class CreateMinisterialEffectUseCase
    {
        private ICRUDRepository _crudRepository;
        private IMapper _mapper;
        public CreateMinisterialEffectUseCase(ICRUDRepository crudRepository, IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<MinisterialEffect> Execute(CreateMinisterialEffectInput input)
        {
            var discipline = _crudRepository.GetByIdAsync<Discipline>(input.DisciplineId);
            var effect = _mapper.Map<CreateMinisterialEffectInput, MinisterialEffect>(input);
            effect.FieldOfKnowledgeId = (await discipline).FieldOfKnowledgeId;
            //TODO TEGO TEZ NIE MA NA MOCKUPACH, ma byc?
            effect.Profile = Profile.Practical;
            var addedEffect = await _crudRepository.AddAsync(effect);
            return addedEffect;
        }



    }
}
