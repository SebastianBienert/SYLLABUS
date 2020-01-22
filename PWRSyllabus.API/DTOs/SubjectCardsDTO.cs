using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabusAPI.DTOs
{
    public class SubjectCardDTO
    {
        public int Id { get; set; }
        public string SubjectCode { get; set; }
        public string NameInPolish { get; set; }
        public string NameInEnglish { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
