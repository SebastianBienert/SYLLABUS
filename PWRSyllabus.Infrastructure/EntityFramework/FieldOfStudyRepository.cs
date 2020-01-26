using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public class FieldOfStudyRepository: IFieldOfStudyRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public FieldOfStudyRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FieldOfStudy>> GetAllFieldsOfStudy()
        {
            var fieldsOfStudy = await _dbContext.FieldOfStudies
                .Include(x => x.Faculty)
                .ToListAsync();

            return fieldsOfStudy;
        }
    }
}
