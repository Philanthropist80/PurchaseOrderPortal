﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obermind.Operation.Data.Access.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);

        void Add<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        void Remove<T>(T obj) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void Commit();
        Task CommitAsync();
        void Attach<T>(T obj) where T : class;
    }
}
