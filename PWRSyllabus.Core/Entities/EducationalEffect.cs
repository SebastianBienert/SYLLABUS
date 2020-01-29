using System.Collections.Generic;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Core.Entities
{
    public class EducationalEffect : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public List<EducationalEffectSubjectCard> EducationalEffectSubjectCards { get; set; }
        public List<MinisterialEffectEducationalEffect> MinisterialEffectEducationalEffects { get; set; }
    }
}
