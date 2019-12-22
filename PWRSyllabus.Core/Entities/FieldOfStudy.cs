using System.Collections.Generic;

namespace PWRSyllabus.Core.Entities
{
    public class FieldOfStudy : BaseEntity
    {
        public string Specialization { get; set; }
        public string Name { get; set; }
        public List<FieldOfStudyDiscipline> FieldOfStudyDisciplines { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        public List<StudyProgram> StudyPrograms { get; set; }
    }
}
