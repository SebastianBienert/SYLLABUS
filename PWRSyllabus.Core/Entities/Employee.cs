using System.Collections.Generic;

namespace PWRSyllabus.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<SubjectCard> Subjects { get; set; }
    }
}
