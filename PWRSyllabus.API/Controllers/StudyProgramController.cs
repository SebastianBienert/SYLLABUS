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
            var studyProgramss = await _repository.GetAllStudiesPrograms();
            var studyPlanDtos = studyProgramss.Select(d => _mapper.Map<StudyProgram, StudyProgramDTO>(d));

            return Ok(studyPlanDtos);
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchSubjectCards([FromBody] StudyProgramSearchParameters studyProgramSearchParameters)
        {
            var studyPrograms = await _repository.SearchStudyPrograms(
                studyProgramSearchParameters.SearchText,
                studyProgramSearchParameters.PageSize,
                studyProgramSearchParameters.PageNumber
            );
            var studyProgramsDtos = _mapper.Map<IEnumerable<StudyProgram>, IEnumerable<StudyProgramDTO>>(studyPrograms);

            return Ok(studyProgramsDtos);
        }

        [HttpGet("{id}", Name = "GetStudyProgramById")]
        public async Task<IActionResult> GetStudyProgramDetails(int id)
        {
            var studyPrograms = await _repository.GetStudyProgram(id);
            var studyProgramDto = _mapper.Map<StudyProgram, StudyProgramDTO>(studyPrograms);

            return Ok(studyProgramDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudyProgram([FromRoute] int id, [FromBody]StudyProgramDTO studyProgramDto)
        {
            var studyProgram = _mapper.Map<StudyProgramDTO, StudyProgram>(studyProgramDto);
            await _crudRepository.UpdateAsync(studyProgram);
            return Ok(studyProgram);
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