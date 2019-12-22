using System.Collections.Generic;

namespace PWRSyllabus.Core.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }
        public List<FieldOfStudy> FieldOfStudies { get; set; }
    }
}
