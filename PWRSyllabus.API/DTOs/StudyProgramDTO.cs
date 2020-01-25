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
        public FieldOfStudyDTO FieldOfStudy { get; set; }
        public string FormOfStudies { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
        public List<SubjectCardDTO> SubjectCards { get; set; }
    }
}
