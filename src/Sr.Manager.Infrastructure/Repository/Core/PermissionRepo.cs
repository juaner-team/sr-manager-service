using Sr.Manager.Core.Domains.Entities.Core;
using Sr.Manager.Core.Interface.IRepositories.Core;
using Sr.Manager.Core.Security;
using Sr.Manager.Infrastructure.Repository.Base;
using FreeSql;

namespace Sr.Manager.Infrastructure.Repository.Core
{
    public class PermissionRepo : AuditBaseRepo<PermissionEntity>, IPermissionRepo
    {
        public PermissionRepo(UnitOfWorkManager unitOfWorkManager, ICurrentUser currentUser) : base(unitOfWorkManager, currentUser)
        {
        }
    }
}
