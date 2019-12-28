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

        public async Task<MinisterialEffect> UpdateMinisterialEffect(MinisterialEffect ministerialEffect)
        {
            var exist = _dbContext.MinisterialEffects.Find(ministerialEffect.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(ministerialEffect);

            await _dbContext.SaveChangesAsync();
            return ministerialEffect;
        }

        public async Task DeleteMinisterialEffect(int ministerialEffectId)
        {
            var delete =
                _dbContext.MinisterialEffects.Remove(
                    _dbContext.MinisterialEffects.First(me => me.Id == ministerialEffectId));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MinisterialEffect> CreateMinisterialEffect(MinisterialEffect ministerialEffect)
        {
            var added = _dbContext.MinisterialEffects.Add(ministerialEffect);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
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
