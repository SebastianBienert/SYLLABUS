namespace PWRSyllabus.Core.Entities
{
    public class Class : BaseEntity
    {
        public int ClassNumber { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
