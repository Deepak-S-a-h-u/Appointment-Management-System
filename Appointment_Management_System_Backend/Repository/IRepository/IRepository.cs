using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Appointment_Management_System_Backend.Repository.IRepository
{
    public interface IRepository<T>where T:class
    {
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Update(T entity);
        T Get(int id);    //find
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>orderby=null,
            string includeProperties=null    //category,covertype
            );
        T FirstOrDefault(
          Expression<Func<T, bool>> filter = null,
          string includeproperties = null
            );
    }
}
