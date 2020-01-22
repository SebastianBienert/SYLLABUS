using PWRSyllabus.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PWRSyllabus.Core.Interfaces
{
    public interface ISubjectCardRepository
    {
        Task<IEnumerable<SubjectCard>> GetAllSubjectCards();
        Task<SubjectCard> GetSubjectCard(int SubjectCardId);
    }
}
