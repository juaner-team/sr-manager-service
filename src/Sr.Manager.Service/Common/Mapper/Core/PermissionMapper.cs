using AutoMapper;
using Sr.Manager.Core.Domains.Entities.Core;
using Sr.Manager.Service.Core.Permission.Input;

namespace Sr.Manager.Service.Common.Mapper.Core
{
    public class PermissionMapper : Profile
    {
        public PermissionMapper()
        {
            CreateMap<PermissionEntity, PermissionDto>();
            CreateMap<ModifyPermissionDto, PermissionEntity>();
        }
    }
}
