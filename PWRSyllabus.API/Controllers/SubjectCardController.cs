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
    public class SubjectCardController : ControllerBase
    {
        private readonly ICRUDRepository _crudRepository;
        private readonly IMapper _mapper;
        private readonly ISubjectCardRepository _subjectCardRepository;

        public SubjectCardController(ICRUDRepository crudRepository, IMapper mapper, ISubjectCardRepository subjectCardRepository)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
            _subjectCardRepository = subjectCardRepository;
        }

        // GET: api/SubjectCard
        [HttpGet]
        public async Task<IEnumerable<SubjectCardDTO>> GetAllSubjectCards()
        {
            var subjectCards = await _subjectCardRepository.GetAllSubjectCards();
            var subjectCardDtos = subjectCards.Select(d => _mapper.Map<SubjectCard, SubjectCardDTO>(d));

            return subjectCardDtos;
        }

        // GET: api/SubjectCard/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SubjectCard
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SubjectCard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
