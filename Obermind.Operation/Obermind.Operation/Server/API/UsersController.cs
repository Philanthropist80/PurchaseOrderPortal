using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Access.Constants;
using Obermind.Operation.Data.Model.Security;
using Obermind.Operation.Server.Filters;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.API
{
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersContract _userManager;
        private readonly IAutoMapper _mapper;

        public UsersController(IUsersContract userManager, IAutoMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [QueryableResult]
        public IQueryable<UserModel> Get()
        {
            var result = _userManager.Get();
            var models = _mapper.Map<User, UserModel>(result);
            return models;
        }

        [HttpGet("{id}")]
        public UserModel Get(string id)
        {
            var item = _userManager.Get(id);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<UserModel> Post([FromBody] CreateUserModel requestModel)
        {
            var item = await _userManager.Create(requestModel);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpPost("{id}/password")]
        [ValidateModel]
        public async Task ChangePassword(string id, [FromBody] ChangeUserPasswordModel requestModel)
        {
            await _userManager.ChangePassword(id, requestModel);
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<UserModel> Put(string id, [FromBody] UpdateUserModel requestModel)
        {
            var item = await _userManager.Update(id, requestModel);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _userManager.Delete(id);
        }
    }
}
