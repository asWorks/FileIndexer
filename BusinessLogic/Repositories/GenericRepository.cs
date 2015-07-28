using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;



namespace BusinessLogic.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private IndexerModel _IndexerModel;
        internal DbSet<TEntity> dbSet;


        public GenericRepository(IndexerModel model)
        {
            _IndexerModel = model;
            this.dbSet = _IndexerModel.Set<TEntity>();

        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();

        }

        public virtual IEnumerable<TEntity> GetAllTest(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = dbSet.Where(filter);
            return query.ToList();
        }

        public T GetSingle<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public T GetSingle<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter, List<System.Linq.Expressions.Expression<Func<T, object>>> subSelectors)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public System.Data.Common.DbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}


