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

namespace PWRSyllabusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraceMatrixController : ControllerBase
    {
        private readonly ITraceMatrixRepository _traceMatrixRepository;
        private readonly IMapper _mapper;
        public TraceMatrixController(ITraceMatrixRepository traceMatrixRepository, IMapper mapper)
        {
            _traceMatrixRepository = traceMatrixRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTraceMatrix()
        {
            var effects = await _traceMatrixRepository.GetTraceMatrix();
            var matrixRows = _mapper.Map<List<MinisterialEffectEducationalEffect>, List<MatrixRow>>(effects);
            var matrix = new TraceMatrixDTO(matrixRows);

            return Ok(matrix);
        }
    }
}