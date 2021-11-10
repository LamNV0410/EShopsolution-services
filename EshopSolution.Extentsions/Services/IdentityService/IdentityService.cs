using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions.Services.Identify;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace EshopSolution.Extensions.Services.IdentityService
{
    /// <summary>
    /// Service xác thực
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor httpContexAccessor;
        IOptions<ServiceSettings> _settings;

        public IdentityService(IHttpContextAccessor httpContexAccessor, IOptions<ServiceSettings> settings)
        {
            this.httpContexAccessor = httpContexAccessor ?? throw new ArgumentNullException(nameof(httpContexAccessor));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public EShopToken GetUserIdentity()
        {
            if (!httpContexAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var userClaim = httpContexAccessor.HttpContext.User.Claims.ToList();

            var userInfo = EShopToken.ConvertModelFromClaim(userClaim);

            return userInfo;
        }

        public string GenerateToken(EShopToken tokenModel)
        {
            var claims = EShopToken.GenarateToClaim(tokenModel);

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Audience.Secret));
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Audience.Iss,
                audience: _settings.Value.Audience.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromHours(24)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public bool IsAuthenticated()
        {
            return httpContexAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
