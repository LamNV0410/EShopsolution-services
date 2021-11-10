using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EshopSolution.Extensions.Services.Identify
{
    public class EShopToken
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public Guid UserTypeId { get; set; }
        public string Email { get; set; }

        public static List<Claim> GenarateToClaim(EShopToken tokenModel)
        {
            return new List<Claim>()
            {
                new Claim(EShopClaimTypes.UserId, tokenModel.Id.ToString()),
                new Claim(EShopClaimTypes.FullName, tokenModel.FullName.ToString()),
                new Claim(EShopClaimTypes.Avatar, tokenModel.Avatar?.ToString() ?? string.Empty),
                new Claim(EShopClaimTypes.Email, tokenModel.Email.ToString()),
                new Claim(EShopClaimTypes.UserTypeId, tokenModel.UserTypeId.ToString()),
            };
        }

        public static EShopToken ConvertModelFromClaim(List<Claim> claims)
        {
            return new EShopToken()
            {
                Id = new Guid(claims.FirstOrDefault(x => x.Type == EShopClaimTypes.UserId).Value),
                FullName = claims.FirstOrDefault(x => x.Type == EShopClaimTypes.FullName).Value,
                Avatar = claims.FirstOrDefault(x => x.Type == EShopClaimTypes.Avatar).Value,
                Email = claims.FirstOrDefault(x => x.Type == EShopClaimTypes.Email).Value,
                UserTypeId = new Guid(claims.FirstOrDefault(x => x.Type == EShopClaimTypes.UserTypeId).Value),
            };
        }
    }
}
