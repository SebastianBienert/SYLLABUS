namespace PWRSyllabus.Core.Entities
{
    public class StudyPlanSubjectCard
    {
        public StudyPlan StudyPlan { get; set; }
        public int StudyPlanId { get; set; }
        public SubjectCard SubjectCard { get; set; }
        public int SubjectCardId { get; set; }
        public int Semester { get; set; }
    }
}
