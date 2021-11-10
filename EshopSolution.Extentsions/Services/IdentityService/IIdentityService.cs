using EshopSolution.Extensions.Services.Identify;

namespace CLSK12.BaseService.Services.IdentityService
{
    public interface IIdentityService
    {
        EShopToken GetUserIdentity();
        string GenerateToken(EShopToken tokenModel);
        bool IsAuthenticated();
    }
}
