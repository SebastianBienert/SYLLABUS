using System.Collections.Generic;

namespace PWRSyllabus.Core.Entities
{
    public class FieldOfKnowledge : BaseEntity
    {
        public string Name { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<MinisterialEffect> MinisterialEffects { get; set; }
    }
}
