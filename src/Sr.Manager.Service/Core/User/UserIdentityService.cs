using Sr.Manager.Core.Domains.Entities.Core;
using Sr.Manager.Core.Interface.IRepositories.Core;
using Sr.Manager.ToolKits.Utils;
using System;
using System.Threading.Tasks;

namespace Sr.Manager.Service.Core.User;

public class UserIdentityService : IUserIdentityService
{
    private readonly IUserIdentityRepo _userIdentityRepo;
    public UserIdentityService(IUserIdentityRepo userIdentityRepository)
    {
        _userIdentityRepo = userIdentityRepository;
    }
    public Task ChangePasswordAsync(long userId, string newpassword)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> VerifyUserPasswordAsync(long userId, string password)
    {
        UserIdentityEntity userIdentity = await GetFirstByUserIdAsync(userId);

        return userIdentity != null && EncryptUtil.Verify(userIdentity.Credential, password);
    }

    /// <summary>
    /// 通过Id获取用户信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<UserIdentityEntity> GetFirstByUserIdAsync(long userId)
    {
        return await _userIdentityRepo
            .Where(r => r.CreateUserId == userId && r.IdentityType == UserIdentityEntity.Password)
            .ToOneAsync();
    }
}
