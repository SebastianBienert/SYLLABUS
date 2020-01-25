using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWRSyllabusAPI.DTOs
{
    public class TraceMatrixDTO
    {
        public List<MatrixRow> Rows { get; }

        public TraceMatrixDTO(List<MatrixRow> rows)
        {
            Rows = rows;
        }
    }

    public class MatrixRow
    {
        public string MinisterialEffectCode { get; set; }
        public int MinisterialEffectID { get; set; }
        public string MinisterialEffectDescription { get; set; }
        public string EducationalEffectCode { get; set; }
        public int EducationalEffectID { get; set; }
        public string EducationalEffectDescription { get; set; }
    }
}
