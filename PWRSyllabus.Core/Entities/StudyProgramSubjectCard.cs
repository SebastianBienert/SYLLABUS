namespace PWRSyllabus.Core.Entities
{
    public class StudyProgramSubjectCard
    {
        public StudyProgram StudyProgram { get; set; }
        public int StudyProgramId { get; set; }
        public SubjectCard SubjectCard { get; set; }
        public int SubjectCardId { get; set; }

    }
}
