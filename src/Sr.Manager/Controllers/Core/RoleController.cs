using Sr.Manager.Core.Domains.Common;
using Sr.Manager.Core.Domains.Common.Consts;
using Sr.Manager.Service.Core.Permission;
using Sr.Manager.Service.Core.Permission.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sr.Manager.Controllers.Core
{
    /// <summary>
    /// 权限管理
    /// </summary>
    [Route("api/admin/role")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v2)]
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get/all")]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v2)]
        public async Task<ServiceResult<List<RoleDto>>> GetAllAsync()
        {
            var result = await _roleService.GetAllAsync();
            return ServiceResult<List<RoleDto>>.Successed(result);
        }
    }
}
