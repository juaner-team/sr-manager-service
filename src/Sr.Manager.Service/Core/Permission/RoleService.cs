using Sr.Manager.Core.Interface.IRepositories.Core;
using Sr.Manager.Service.Base;
using Sr.Manager.Service.Core.Permission.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sr.Manager.Service.Core.Permission
{
    public class RoleService : ApplicationService, IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var entitys = await _roleRepo.Select.Where(r => r.IsDeleted == false).ToListAsync();
            var dtos = entitys.Select(e => Mapper.Map<RoleDto>(e)).ToList();
            return dtos;
        }
    }
}
