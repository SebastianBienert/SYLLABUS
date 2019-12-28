using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PWRSyllabus.Core.Entities;


namespace PWRSyllabus.Core
{
    public interface ICRUDRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(int entityId) where T : BaseEntity;
    }
}
