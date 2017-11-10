using Com.Qualcomm.Qswat.Core.Interface;
using Com.Qualcomm.Qswat.Model;
using System.Linq;

namespace Com.Qualcomm.Qswat.Service
{
    /// <summary>
    /// a generic buisess service that do simple CRUD for Type T
    /// </summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public class GenericBusinessServices<T> : IGenericBusinessService<T> where T : BaseEntity
    {
        #region fields

        protected IRepository<T> Repository;
        #endregion

        #region ctor

        public GenericBusinessServices(IRepository<T> repository)
        {
            Repository = repository;
        }
        #endregion
        public virtual void Delete(params T[] entities)
        {
            foreach (var entity in entities)
            {
                Repository.Delete(entity);
            }
        }

        public virtual T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public virtual void Insert(params T[] entities)
        {
            foreach (var entity in entities)
            {
                Repository.Insert(entity);
            }
        }

        public virtual IQueryable<T> QueryAllNonTracking()
        {
            return Repository.TableNoTracking;
        }

        public virtual IQueryable<T> QueryAll()
        {
            return Repository.Table;
        }

        public virtual void Update(T entity)
        {
            Repository.Update(entity);
        }
    }
}
