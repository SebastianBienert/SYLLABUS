using PWRSyllabus.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PWRSyllabus.Core.Interfaces
{
    public interface IFieldOfStudyRepository
    {
        Task<IEnumerable<FieldOfStudy>> GetAllFieldsOfStudy();
    }
}
