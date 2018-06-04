﻿using LibraryManagment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly LibraryDbContext _context;

        public Repository(LibraryDbContext context)
        {

            _context = context;

        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
             _context.Add(entity);

            _context.SaveChanges();

        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();

        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
           return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int Id)
        {
           return  _context.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
