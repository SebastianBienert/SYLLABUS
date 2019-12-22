using System.Collections.Generic;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Core.Entities
{
    public class StudyProgram : BaseEntity
    {
        public string Description { get; set; }
        public FormOfStudies FormOfStudies { get; set; }
        public Profile Profile { get; set; }
        public Level Level { get; set; }
        public string LanguageOfStudy { get; set; }
        public FieldOfStudy FieldOfStudy { get; set; }
        public int FieldOfStudyId { get; set; }

        public StudyPlan StudyPlan { get; set; }

        public List<StudyProgramSubjectCard> StudyProgramSubjectCards { get; set; }
    }
}
