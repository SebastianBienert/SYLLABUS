using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Interfaces;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public class TraceMatrixRepository : ITraceMatrixRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public TraceMatrixRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MinisterialEffectEducationalEffect>> GetTraceMatrix()
        {
            var matrix = await _dbContext.MinisterialEffectEducationalEffects
                .Include(x => x.MinisterialEffect)
                .Include(x => x.EducationalEffect)
                .ToListAsync();

            return matrix;
        }
    }

    
}
