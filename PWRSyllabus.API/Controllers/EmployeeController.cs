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
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICRUDRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeController(ICRUDRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employeeDtos = (await  _repository.ListAsync<Employee>())
                .Select(e => _mapper.Map<Employee, EmployeeDTO>(e));

            return Ok(employeeDtos);
        }
    }
}