using Sr.Manager.Core.Domains.Entities.Core;
using Sr.Manager.Core.Interface.IRepositories.Base;

namespace Sr.Manager.Core.Interface.IRepositories.Core
{
    public interface IFileRepo : IAuditBaseRepo<FileEntity>
    {
        string GetFileUrl(string path);
    }
}
