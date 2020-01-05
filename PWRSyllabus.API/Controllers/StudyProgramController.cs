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
using PWRSyllabus.Core.UseCases.CreateStudyProgram;
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

        [HttpPost]
        public async Task<IActionResult> CreateStudyPlan(StudyProgramDTO studyProgramDto)
        {
            var studyProgram = _mapper.Map<StudyProgramDTO, StudyProgram>(studyProgramDto);
            var addedEffect = await _crudRepository.AddAsync(studyProgram);
            return CreatedAtRoute("GetMinisterialEffectById", new { id = addedEffect.Id });
        }
    }
}