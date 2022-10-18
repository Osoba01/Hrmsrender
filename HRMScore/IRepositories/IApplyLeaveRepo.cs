using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories.IBase;
using System.Linq.Expressions;

namespace HRMS.Domain.IRepositories
{
    public interface IApplyLeaveRepo : IBaseRepo<ApplyLeave>
    {
        Task<IEnumerable<ApplyLeave>> ApplyLeaveByPredicate(Expression<Func<ApplyLeave, bool>> predicate);
        Task<IEnumerable<ApplyLeave>> OnGoingLeave();
    }


}
