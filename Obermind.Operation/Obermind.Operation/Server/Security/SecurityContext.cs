using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Model.Security;
using Obermind.Operation.Server.Mapping.Contracts;


namespace Obermind.Operation.Server.Security
{
    public class SecurityContext
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISecurityContract _securityManager;
        private readonly IAutoMapper _mapper;
        private UserModel _user;

        public SecurityContext(IHttpContextAccessor contextAccessor, ISecurityContract securityManager, IAutoMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _securityManager = securityManager;
            _mapper = mapper;
        }

        public UserModel User
        {
            get
            {
                if (_user != null) return _user;

                if (!_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    throw new UnauthorizedAccessException();
                }

                var username = _contextAccessor.HttpContext.User.Identity.Name;
                var _userDal = this._securityManager.GetUser(username);

                if (_userDal == null)
                {
                    throw new UnauthorizedAccessException("User is not found");
                }

                _mapper.Map<User, UserModel>(_userDal, _user);

                return _user;
            }
        }

        public bool IsAdministrator
        {
            get { return this._securityManager.IsAdminUser(User.Username); }
        }
    }



}

