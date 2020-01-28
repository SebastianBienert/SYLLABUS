using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<SubjectCard>> SearchSubjectCards(string query, int pageSize, int pageNumber)
        {
            var subjectCards = await _dbContext.SubjectCards
                .Include(sc => sc.Courses).ThenInclude(sc => sc.Classes)
                .Where(x => x.NameInEnglish.Contains(query) || 
                            x.NameInPolish.Contains(query) || 
                            x.Objectivties.Contains(query) || 
                            x.Prerequisites.Contains(query) || 
                            x.PrimaryLiterature.Contains(query) || 
                            x.SecondaryLiterature.Contains(query) || 
                            x.Courses.Any(c => c.Classes.Any(cl => cl.Description.Contains(query))))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return subjectCards;
        }
    }
}
