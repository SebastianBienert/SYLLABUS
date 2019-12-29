using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        public StudyProgramController(IStudyProgramRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyPlans()
        {
            var minsiterialEffects = await _repository.GetAllStudiesPrograms();
            var studyPlanDtos = minsiterialEffects.Select(d => _mapper.Map<StudyProgram, StudyProgramDTO>(d));

            return Ok(studyPlanDtos);
        }
    }
}