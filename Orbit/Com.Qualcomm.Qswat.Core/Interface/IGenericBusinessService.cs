using Com.Qualcomm.Qswat.Model;
using System.Linq;

namespace Com.Qualcomm.Qswat.Core.Interface
{
    public interface IGenericBusinessService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> QueryAllNonTracking();

        IQueryable<TEntity> QueryAll();

        TEntity GetById(int id);

        void Insert(params TEntity[] entities);

        void Update(TEntity entity);

        void Delete(params TEntity[] entities);

    }
}
