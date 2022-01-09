using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Data.Access.Constants;
using Obermind.Operation.Data.Access.DAL.Contracts;
using Obermind.Operation.Data.Model.Security;
using Obermind.Operation.Security.Contracts;

namespace Obermind.Operation.Business.Manager.Security
{
    public class SecurityManager : ISecurityContract
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IUsersContract _usersManager;
        

        public SecurityManager(IUnitOfWork uow, ITokenBuilder tokenBuilder, IUsersContract usersManager)
        {
            _uow = uow;
            _tokenBuilder = tokenBuilder;
            _usersManager = usersManager;
        }


        public User GetUser(string userName)
        {
            var _user = _uow.Query<User>()
                .Where(x => x.Username == userName)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            return _user;
        }

        public bool IsAdminUser(string userName)
        {
            var _user = _uow.Query<User>()
                .Where(x => x.Username == userName)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            if (_user == null) return false;

            return _user.Roles.Any(x => x.Role.Name == Roles.admin);
        }
    }
}
