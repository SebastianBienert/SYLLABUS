using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWRSyllabusAPI.DTOs
{
    public class StudyProgramSearchParameters
    {
        public string SearchText { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
