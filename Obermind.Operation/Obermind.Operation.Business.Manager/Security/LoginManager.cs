using Obermind.Operation.Business.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.API.Common;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Model;
using Obermind.Operation.Data.Access.DAL.Contracts;
using Obermind.Operation.Data.Access.Helpers;
using Obermind.Operation.Data.Model.Security;
using Obermind.Operation.Security;
using Obermind.Operation.Security.Auth;
using Obermind.Operation.Security.Contracts;

namespace Obermind.Operation.Business.Manager.Security
{
    public class LoginManager : ILoginContract
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IUsersContract _usersManager;
        private readonly ISecurityContract _context;
        private Random _random;

        public LoginManager(IUnitOfWork uow, ITokenBuilder tokenBuilder, IUsersContract usersManager, ISecurityContract context)
        {
            _random = new Random();
            _uow = uow;
            _tokenBuilder = tokenBuilder;
            _usersManager = usersManager;
            _context = context;
        }

        public IUserToken Authenticate(string username, string password)
        {
            var user = (from u in _uow.Query<User>()
                        where u.Username == username && !u.IsDeleted
                        select u)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            if (user == null)
            {
                throw new BadRequestException("username/password aren't right");
            }

            if (string.IsNullOrWhiteSpace(password) || !user.Password.VerifyWithBCrypt(password))
            {
                throw new BadRequestException("username/password aren't right");
            }

            var expiresIn = DateTime.Now + TokenAuthOption.ExpiresSpan;
            var token = _tokenBuilder.Build(user.Username, user.Roles.Select(x => x.Role.Name).ToArray(), expiresIn);

            return new UserToken
            {
                ExpiresAt = expiresIn,
                Token = token,
                User = user
            };
        }

        public async Task<User> Register(RegisterModel model)
        {
            var requestModel = new CreateUserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Username = model.Username,
                Email = model.Email,
                Roles = new string [] { "user" },
            };

            var user = await _usersManager.Create(requestModel);
            return user;
        }

        public async Task ChangePassword(string username, ChangeUserPasswordModel requestModel)
        {
            await _usersManager.ChangePassword(username, requestModel);
        }
    }
}

