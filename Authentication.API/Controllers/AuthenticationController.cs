using Authentication.API.Application.Queries;
using Authentication.API.Application.Queries.Requests;
using Authentication.API.Application.Queries.Responses;
using CLSK12.BaseService.Services.IdentityService;
using EshopSolution.Extensions.Exceptions;
using EshopSolution.Extensions.Extensions;
using EshopSolution.Extensions.Services.Identify;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Authentication.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserQueries _userQueries;
        private readonly IIdentityService _identityService;
        public AuthenticationController(
            IMediator mediator,
            IUserQueries userQueries,
            IIdentityService identityService
            )
        {
            _mediator = mediator;
            _userQueries = userQueries;
            _identityService = identityService;
        }

        [HttpGet("infor")]
        public async Task<IActionResult> Get()
        {
            return Ok("Order service infor");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var userInfo = await _userQueries.GetUsersAsync(request.UserName);
            if (userInfo == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy người dùng", null);
            }

            #region check
            if (!SHA256Hasher.Validate(request.Password, userInfo.Salt, userInfo.Password))
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Không tìm thấy người dùng", null);
            }

            #endregion

            #region generate token
            var tokenModel = new EShopToken()
            {
                Id = userInfo.Id,
                Email = userInfo.Email,
                FullName = userInfo.FullName,
                UserTypeId = userInfo.UserTypeRole
            };

            var newToken = _identityService.GenerateToken(tokenModel);
            #endregion

            #region info client
            var connectionInfo = HttpContext.Connection;
            #endregion

            return Ok(new LoginResponse()
            {
                Token = newToken,
            });
        }
    }
}
