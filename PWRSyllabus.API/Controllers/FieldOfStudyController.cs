using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PWRSyllabus.Core;
using PWRSyllabus.Core.Entities;
using PWRSyllabusAPI.DTOs;

namespace PWRSyllabus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldOfStudyController : ControllerBase
    {
        private readonly ICRUDRepository _repository;
        private readonly IMapper _mapper;
        public FieldOfStudyController(ICRUDRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyPlans()
        {
            var fieldOfStudiesDto = (await _repository.ListAsync<FieldOfStudy>())
                .Select(d => _mapper.Map<FieldOfStudy, FieldOfStudyDTO>(d));

            foreach(var f in fieldOfStudiesDto)
            {
                f.Faculty = "aaa";
            }

            return Ok(fieldOfStudiesDto);
        }
    }
}