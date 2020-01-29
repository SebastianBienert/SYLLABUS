using System;
using System.Collections.Generic;
using System.Text;

namespace PWRSyllabus.Core.UseCases.GenerateSubjectCardReport
{
    public class SubjectCardPDF
    {
        public IEnumerable<byte> Data { get;  }
        public string SubjectCardCode { get; }
        public int SubjectCardID { get;  }

        public SubjectCardPDF(IEnumerable<byte> data, string subjectCardCode, int subjectCardId)
        {
            Data = data;
            SubjectCardCode = subjectCardCode;
            SubjectCardID = subjectCardId;
        }
    }
}
