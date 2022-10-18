using HRMS.Domain.Entities.Base;
using HRMS.Domain.IRepositories.IBase;
using HRMSinfrastructure.Data;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;


namespace HRMS.Infrastructure.Repositories.BaseRepo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        private readonly HRMSDbContext context;

        public BaseRepo(HRMSDbContext _context)
        {
            context = _context;
        }
        public T AddEntity(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void PatchUpdate(T entity)
        {
            context.Attach(entity).State = EntityState.Modified;
        }
        public void RemoveEntity(T entity)
        {
            context.Set<T>().Remove(entity);

        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<T?> FindAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetToN(int n)
        {
            return await context.Set<T>().Take(n).ToListAsync();
        }

        public bool IsExist(Guid id)
        {
            return context.Set<T>().Where(x => x.Id == id).Any();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
    }
}
