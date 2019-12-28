using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core;
using PWRSyllabus.Core.Entities;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public class CRUDRepository : ICRUDRepository
    {
        private readonly PWRSyllabusContext _dbContext;

        public CRUDRepository(PWRSyllabusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync<T>(int entityId) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(_dbContext.Set<T>().First(x => x.Id == entityId));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
