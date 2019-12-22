using System.Collections.Generic;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Core.Entities
{
    public class MinisterialEffect : BaseEntity
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public Profile Profile { get; set; }
        public Level Level { get; set; }
        public FieldOfKnowledge FieldOfKnowledge { get; set; }
        public int FieldOfKnowledgeId { get; set; }
        public List<MinisterialEffectEducationalEffect> MinisterialEffectEducationalEffects { get; set; }

    }
}
