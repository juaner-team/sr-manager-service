using System.Security.Claims;

namespace Sr.Manager.Core.Security
{
    public interface ICurrentUser
    {
        long? Id { get; }

        string UserName { get; }

        Claim FindClaim(string claimType);

        Claim[] FindClaims(string claimType);

        Claim[] GetAllClaims();


        bool IsInGroup(long groupId);
    }
}
