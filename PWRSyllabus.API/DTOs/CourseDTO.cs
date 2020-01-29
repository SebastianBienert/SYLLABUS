using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabusAPI.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public int ECTS { get; set; }
        public int ZZU { get; set; }
        public int CNPS { get; set; }
        public string CourseForm { get; set; }
        public string FormOfCrediting { get; set; }
        public IEnumerable<ClassDTO> Classes { get; set; }
    }
}
