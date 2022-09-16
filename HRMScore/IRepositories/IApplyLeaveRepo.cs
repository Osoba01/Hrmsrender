using HRMScore.Entities;
using HRMScore.IRepositories.ICommandRepo.IBase;
using System.Linq.Expressions;

namespace HRMScore.IRepositories
{
    public interface IApplyLeaveRepo: IBaseRepo<ApplyLeave>
    {
        Task<IEnumerable<ApplyLeave>> ApplyLeaveByPredicate(Expression<Func<ApplyLeave, bool>> predicate);
    }
    

}
