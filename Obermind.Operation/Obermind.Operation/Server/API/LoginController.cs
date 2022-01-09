using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Server.Filters;
using Obermind.Operation.Server.Mapping.Contracts;
using Obermind.Operation.Business.Manager.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obermind.Operation.Server.API
{
    [EnableCors("AllowOrigin")]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginContract _loginManager;
        private readonly IAutoMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginController(ILoginContract loginManager, IAutoMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _loginManager = loginManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        
        [HttpPost("authenticate")]
        [ValidateModel]
        public UserTokenModel Authenticate([FromBody] LoginModel model)
        {
            var result = _loginManager.Authenticate(model.Username, model.Password);

            var resultModel = _mapper.Map<UserTokenModel>(result);

            return resultModel;
        }

        
        [HttpPost("register")]
        [ValidateModel]
        public async Task<UserModel> Register([FromBody] RegisterModel model)
        {
            var result = await _loginManager.Register(model);
            var resultModel = _mapper.Map<UserModel>(result);
            return resultModel;
        }

        [HttpPost("Password")]
        [ValidateModel]
        [Authorize]
        public async Task ChangePassword([FromBody] ChangeUserPasswordModel requestModel)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            await _loginManager.ChangePassword(username, requestModel);
        }
    }
}
