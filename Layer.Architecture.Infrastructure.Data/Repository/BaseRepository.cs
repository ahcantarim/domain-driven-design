using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Architecture.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        #region IBaseRepository

        public void Insert(TEntity entity)
        {
            _mySqlContext.Set<TEntity>().Add(entity);
            _mySqlContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _mySqlContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Select(id);
            _mySqlContext.Set<TEntity>().Remove(entity);
            _mySqlContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _mySqlContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _mySqlContext.Set<TEntity>().Find(id);

        #endregion
    }
}
