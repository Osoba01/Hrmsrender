using HRMScore.Entities.Base;
using System.Linq.Expressions;

namespace HRMScore.IRepositories.ICommandRepo.IBase
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        void RemoveEntity(T entity);
        T AddEntity(T entity);
        Task<int> Complete();
        Task<T?> FindAsync(Guid id);
        Task<IEnumerable<T>> GetToN(int n);
        Task<IEnumerable<T>> GetAll();
        void Update(T entity);
        void PatchUpdate(T entity);
        bool IsExist(Guid id);
        Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate);
    }
}
