using AutoMapper;
using PWRSyllabus.Core.Entities;
using PWRSyllabusAPI.DTOs;

namespace PWRSyllabusAPI
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
