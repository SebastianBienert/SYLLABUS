using System.Collections.Generic;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Core.Entities
{
    public class StudyPlan : BaseEntity
    {
        public StudyProgram StudyProgram { get; set; }
        public int StudyProgramId { get; set; }
        public Level Level { get; set; }
        public List<StudyPlanSubjectCard> StudyPlanSubjectCards { get; set; }
    }
}
