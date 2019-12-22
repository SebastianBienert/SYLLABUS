using System.Collections.Generic;

namespace PWRSyllabus.Core.Entities
{
    public class Discipline : BaseEntity
    {
        public string Name { get; set; }
        public List<FieldOfStudyDiscipline> FieldOfStudyDisciplines { get; set; }
        public FieldOfKnowledge FieldOfKnowledge { get; set; }
        public int FieldOfKnowledgeId { get; set; }
    }
}
