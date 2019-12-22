namespace PWRSyllabus.Core.Entities
{
    public class EducationalEffectSubjectCard
    {
        public EducationalEffect EducationalEffect { get; set; }
        public int EducationalEffectId { get; set; }
        public SubjectCard SubjectCard { get; set; }
        public int SubjectCardId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
