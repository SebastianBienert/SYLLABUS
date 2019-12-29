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
    public class MinisterialEffectRepository : IMinisterialEffectRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public MinisterialEffectRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MinisterialEffect>> GetAllMinisterialEffects()
        {
            var ministerialEffects = await _dbContext.MinisterialEffects
                .Include(me => me.FieldOfKnowledge.Disciplines)
                .ToListAsync();

            return ministerialEffects;
        }

        public async Task<MinisterialEffect> GetMinisterialEffect(int ministerialEffectId)
        {
            var ministerialEffect = await _dbContext.MinisterialEffects
                .Include(me => me.FieldOfKnowledge.Disciplines)
                .FirstAsync(me => me.Id == ministerialEffectId);

            return ministerialEffect;
        }
    }
}
