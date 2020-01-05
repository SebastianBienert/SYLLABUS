using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabusAPI.DTOs
{
    public class FieldOfStudyDTO
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
    }
}
