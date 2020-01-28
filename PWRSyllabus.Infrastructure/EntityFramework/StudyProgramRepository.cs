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
    public class StudyProgramRepository: IStudyProgramRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public StudyProgramRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StudyProgram>> GetAllStudiesPrograms()
        {
            var studiesPrograms = await _dbContext.StudyPrograms
                .Include(me => me.StudyProgramSubjectCards)
                .Include(sp => sp.FieldOfStudy)
                .ThenInclude(fos => fos.Faculty)
                .ToListAsync();

            return studiesPrograms;
        }

        public async Task<StudyProgram> GetStudyProgram(int studyProgramId)
        {
            var studyProgram = await _dbContext.StudyPrograms
                .Include(me => me.StudyProgramSubjectCards)
                .ThenInclude(me => me.SubjectCard)
                .Include(me => me.FieldOfStudy)
                .ThenInclude(fos => fos.Faculty)
                .FirstAsync(me => me.Id == studyProgramId);

            return studyProgram;
        }

        public async Task<IEnumerable<StudyProgram>> SearchStudyPrograms(string query, int pageSize, int pageNumber)
        {
            var studiesPrograms = await _dbContext.StudyPrograms
                .Include(me => me.StudyProgramSubjectCards)
                .Include(sp => sp.FieldOfStudy)
                .ThenInclude(fos => fos.Faculty)
                .Where(sp => sp.Description.Contains(query) ||
                             sp.FieldOfStudy.Name.Contains(query) || 
                             sp.FieldOfStudy.Specialization.Contains(query))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return studiesPrograms;
        }
    }
}
