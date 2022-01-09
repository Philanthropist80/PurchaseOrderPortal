using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.API.Common;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Access.DAL.Contracts;
using Obermind.Operation.Data.Access.Helpers;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Manager.Security
{
    public class UsersManager : IUsersContract
    {
        private readonly IUnitOfWork _uow;

        public UsersManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<User> Get()
        {
            var query = GetQuery();

            return query;
        }

        private IQueryable<User> GetQuery()
        {
            return _uow.Query<User>()
                .Where(x => !x.IsDeleted)
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role);
        }

        public User Get(string id)
        {
            var user = GetQuery().FirstOrDefault(x => x.Id ==  id || x.Username == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            return user;
        }

        public async Task<User> Create(CreateUserModel model)
        {
            var username = model.Username.Trim();

            if (GetQuery().Any(u => u.Username == username))
            {
                throw new BadRequestException("The username is already in use");
            }

            var user = new User
            {
                Username = model.Username.Trim(),
                Password = model.Password.Trim().WithBCrypt(),
                FirstName = model.FirstName.Trim(),
                LastName = model.LastName.Trim(),
                Email = model.Email.Trim()

            };

            AddUserRoles(user, model.Roles);

            _uow.Add(user);
            await _uow.CommitAsync();

            return user;
        }

        private void AddUserRoles(User user, string[] roleNames)
        {
            user.Roles.Clear();

            foreach (var roleName in roleNames)
            {
                var role = _uow.Query<Role>().FirstOrDefault(x => x.Name == roleName);

                if (role == null)
                {
                    throw new NotFoundException($"Role - {roleName} is not found");
                }

                user.Roles.Add(new UserRole { User = user, Role = role });
            }
        }

        public async Task<User> Update(string id, UpdateUserModel model)
        {
            var user = GetQuery().FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            user.Username = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            AddUserRoles(user, model.Roles);

            await _uow.CommitAsync();
            return user;
        }

        public async Task Delete(string id)
        {
            var user = GetQuery().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            if (user.IsDeleted) return;

            user.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public async Task ChangePassword(string id, ChangeUserPasswordModel model)
        {
            var user = Get(id);
            user.Password = model.Password.WithBCrypt();
            await _uow.CommitAsync();
        }
    }
}
