using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabusAPI.DTOs
{
    public class MinisterialEffectDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public DisciplineDTO Discipline { get; set; }
        public string DescriptiveCategory { get; set; }
        public string Level { get; set; }
    }
}
