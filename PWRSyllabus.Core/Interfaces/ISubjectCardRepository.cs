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

        Task<SubjectCard> GetSubjectCardForReport(int SubjectCardId);

        Task<IEnumerable<SubjectCard>> SearchSubjectCards(string query, int pageSize, int pageNumber);
    }
}
