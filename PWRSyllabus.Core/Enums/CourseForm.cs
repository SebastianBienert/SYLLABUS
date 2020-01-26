using EnumStringValues;

namespace PWRSyllabus.Core.Enums
{
    public enum CourseForm
    {
        [StringValue("Wykład")]
        Lecture,
        [StringValue("Seminarium")]
        Seminar,
        [StringValue("Laboratorium")]
        Laboratory,
        [StringValue("Ćwiczenia")]
        Classes,
        [StringValue("Projekt")]
        Project
    }
}
