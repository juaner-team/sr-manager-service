using AutoMapper;
using Sr.Manager.Core.Domains.Entities.Core;
using Sr.Manager.Service.Core.Permission.Input;

namespace Sr.Manager.Service.Common.Mapper.Core
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<RoleEntity, RoleDto>();
            CreateMap<ModifyRoleDto, RoleEntity>();
        }
    }

}
