using System;
using System.Collections.Generic;
using System.Text;

namespace PWRSyllabus.Core.UseCases.CreateMinisterialEffect
{
    public class CreateMinisterialEffectInput
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public int DisciplineId { get; set; }
        public string DescriptiveCategory { get; set; }
        public string Level { get; set; }
    }
}
