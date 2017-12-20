using System;
using System.Collections.Generic;
using System.Linq;
using Dot.Library.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Dot.Library.Web.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly LibraryContext _context;

        public Repository(LibraryContext _context)
        {
            this._context = _context;
        }

        public void Delete(T entity)
        {
            _context.Remove<T>(entity);
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}