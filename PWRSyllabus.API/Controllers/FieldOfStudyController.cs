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
    public class FieldOfStudyController : ControllerBase
    {
        private readonly IFieldOfStudyRepository _repository;
        private readonly IMapper _mapper;
        public FieldOfStudyController(IFieldOfStudyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyPlans()
        {
            var fieldOfStudiesDto = (await _repository.GetAllFieldsOfStudy())
                .Select(d => _mapper.Map<FieldOfStudy, FieldOfStudyDTO>(d));


            return Ok(fieldOfStudiesDto);
        }
    }
}