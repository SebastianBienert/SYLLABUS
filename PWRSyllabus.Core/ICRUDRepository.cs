using System;
using System.Collections.Generic;
using System.Text;
using PWRSyllabus.Core.Entities;


namespace PWRSyllabus.Core
{
    public interface ICRUDRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
