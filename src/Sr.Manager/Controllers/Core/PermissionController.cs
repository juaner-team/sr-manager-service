using Sr.Manager.Core.AOP.Filters;
using Sr.Manager.Core.Domains.Common;
using Sr.Manager.Core.Domains.Common.Consts;
using Sr.Manager.Service.Core.Permission;
using Sr.Manager.Service.Core.Permission.Input;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sr.Manager.Controllers.Core;

/// <summary>
/// 权限管理
/// </summary>
[Route("api/admin/permission")]
[ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v2)]
public class PermissionController : ApiControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }
    /// <summary>
    /// 查询所有可分配的权限
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [PermissionAuthorize("查询所有可分配的权限", "管理员")]
    public async Task<ServiceResult<IDictionary<string, IEnumerable<PermissionDto>>>> GetAllPermissions()
    {
        var result = await _permissionService.GetAllStructual();
        return ServiceResult<IDictionary<string, IEnumerable<PermissionDto>>>.Successed(result);
    }
}
