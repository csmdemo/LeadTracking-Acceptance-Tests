using System;
using System.Collections.Generic;

namespace LeadTracking.Core.Data
{
    public interface IRepository<T, in TU> where T:EntityBase<TU>
    {
        void Save(T entity);
        T GetByKey(TU key);
        void Insert(T entity);
        void Update(T entity);
        void Delete(TU key);
        IEnumerable<T> FindAll(Predicate<T> predicate);
    }
}
