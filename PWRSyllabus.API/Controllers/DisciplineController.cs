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

namespace PWRSyllabusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly ICRUDRepository _repository;
        private readonly IMapper _mapper;
        public DisciplineController(ICRUDRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDisciplines()
        {
            var disciplineDtos = _repository.List<Discipline>()
                .Select(d => _mapper.Map<Discipline, DisciplineDTO>(d));

            return Ok(disciplineDtos);
        }
    }
}