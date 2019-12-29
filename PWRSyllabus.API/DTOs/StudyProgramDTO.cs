using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabusAPI.DTOs
{
    public class StudyProgramDTO
    {
        public int Id { get; set; }
        public string Faculty { get; set; }
        public string FieldOfStudy { get; set; }
        public string Specialization { get; set; }
        public string FormOfStudies { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
    }
}