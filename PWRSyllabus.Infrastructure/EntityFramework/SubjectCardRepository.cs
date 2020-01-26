using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public class SubjectCardRepository : ISubjectCardRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public SubjectCardRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SubjectCard>> GetAllSubjectCards()
        {
            var subjectCards = await _dbContext.SubjectCards
                .Include(sc => sc.Supervisor)
                .Include(sc => sc.Courses)
                .ToListAsync();

            return subjectCards;
        }

        public async Task<SubjectCard> GetSubjectCard(int SubjectCardId)
        {
            var SubjectCard = await _dbContext.SubjectCards
                .Include(sc => sc.Supervisor)
                .Include(sc => sc.Courses)
                .FirstAsync(me => me.Id == SubjectCardId);

            return SubjectCard;
        }

        public async Task<SubjectCard> GetSubjectCardForReport(int SubjectCardId)
        {
            var SubjectCard = await _dbContext.SubjectCards
                .Include(sc => sc.StudyProgramSubjectCards).ThenInclude(sp => sp.StudyProgram).ThenInclude(sp => sp.FieldOfStudy)
                .Include(sc => sc.Supervisor)
                .Include(sc => sc.Courses).ThenInclude(c => c.Classes)
                .Include(sc => sc.EducationalEffectSubjectCards).ThenInclude(x => x.EducationalEffect)
                .FirstAsync(me => me.Id == SubjectCardId);

            return SubjectCard;
        }
    }
}
