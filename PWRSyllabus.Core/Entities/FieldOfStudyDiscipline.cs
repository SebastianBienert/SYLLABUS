namespace PWRSyllabus.Core.Entities
{
    public class FieldOfStudyDiscipline
    {
        public int FieldOfStudyId { get; set; }
        public FieldOfStudy FieldOfStudy { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
