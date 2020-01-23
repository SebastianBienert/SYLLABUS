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

namespace PWRSyllabus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyProgramController : ControllerBase
    {
        private readonly IStudyProgramRepository _repository;
        private readonly ICRUDRepository _crudRepository;
        private readonly IMapper _mapper;
        public StudyProgramController(IStudyProgramRepository repository, ICRUDRepository crudRepository, IMapper mapper)
        {
            _repository = repository;
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyPlans()
        {
            var minsiterialEffects = await _repository.GetAllStudiesPrograms();
            var studyPlanDtos = minsiterialEffects.Select(d => _mapper.Map<StudyProgram, StudyProgramDTO>(d));

            return Ok(studyPlanDtos);
        }

        [HttpGet("{id}", Name = "GetStudyProgramById")]
        public async Task<IActionResult> GetStudyProgramDetails(int id)
        {
            var minsiterialEffect = await _repository.GetStudyProgram(id);
            var studyProgramDto = _mapper.Map<StudyProgram, StudyProgramDTO>(minsiterialEffect);

            return Ok(studyProgramDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudyProgram([FromRoute] int id, [FromBody]StudyProgramDTO studyProgramDto)
        {
            //var updateEffectInput = _mapper.Map<StudyProgramDTO, UpdateStudyProgramInput>(studyProgramDto);
            //var editedEffect = await _updateEffect.Execute(updateEffectInput);
            //return Ok(editedEffect);
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudyPlan(StudyProgramDTO studyProgramDto)
        {
            var studyProgram = _mapper.Map<StudyProgramDTO, StudyProgram>(studyProgramDto);
            studyProgram.FieldOfStudy = null;
            
            var addedEffect = await _crudRepository.AddAsync(studyProgram);
            return CreatedAtRoute("GetStudyProgramById", new { id = addedEffect.Id });
        }
    }
}