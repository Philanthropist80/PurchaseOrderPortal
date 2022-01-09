﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Data.Access.DAL.Contracts;


namespace Obermind.Operation.Data.Access.DAL.Agreements
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return new DbTransaction(_context.Database.BeginTransaction(isolationLevel));
        }

        public void Add<T>(T obj)
            where T : class
        {
            var set = _context.Set<T>();
            set.Add(obj);
        }

        public void Update<T>(T obj)
            where T : class
        {
            var set = _context.Set<T>();
            set.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        void IUnitOfWork.Remove<T>(T obj)
        {
            var set = _context.Set<T>();
            set.Remove(obj);
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return _context.Set<T>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Attach<T>(T newUser) where T : class
        {
            var set = _context.Set<T>();
            set.Attach(newUser);
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
