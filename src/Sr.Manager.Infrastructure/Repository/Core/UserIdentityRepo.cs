using Sr.Manager.Core.Domains.Entities.Core;
using Sr.Manager.Core.Interface.IRepositories.Core;
using Sr.Manager.Core.Security;
using Sr.Manager.Infrastructure.Repository.Base;
using FreeSql;

namespace Sr.Manager.Infrastructure.Repository.Core;

class UserIdentityRepo : AuditBaseRepo<UserIdentityEntity>, IUserIdentityRepo
{
    public UserIdentityRepo(UnitOfWorkManager unitOfWorkManager, ICurrentUser currentUser) : base(unitOfWorkManager, currentUser)
    {
    }
}
