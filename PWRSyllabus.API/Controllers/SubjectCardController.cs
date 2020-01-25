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
using PWRSyllabus.Core.UseCases;
using PWRSyllabus.Core.UseCases.GenerateSubjectCardReport;
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
        private readonly GenerateSubjectCardPDFUSeCase _generateSubjectCardPdfUseCase;

        public SubjectCardController(ICRUDRepository crudRepository, IMapper mapper, ISubjectCardRepository subjectCardRepository, GenerateSubjectCardPDFUSeCase generateSubjectCardPdfUseCase)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
            _subjectCardRepository = subjectCardRepository;
            _generateSubjectCardPdfUseCase = generateSubjectCardPdfUseCase;
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
        public async Task<IActionResult> CreateSubjectCard(SubjectCardDTO subjectCardDTO)
        {
            var subjectCard = _mapper.Map<SubjectCardDTO, SubjectCard>(subjectCardDTO);
            subjectCard.Supervisor = null;
            var addedSubjectCard = await _crudRepository.AddAsync(subjectCard);
            //return CreatedAtRoute("GetStudyProgramById", new { id = addedEffect.Id });
            int c = 9;
            c++;
            return null;
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

        [HttpGet("{id}/pdf", Name = "GetSubjectCardPDF")]
        public async Task<IActionResult> GetPDF(int id)
        {
            var pdfBytes = await _generateSubjectCardPdfUseCase.Execute(id);

            return File(pdfBytes, "application/pdf", $"SubjectCard_{id}.pdf");
        }
    }
}
