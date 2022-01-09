using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Contract.Security
{
    public interface IUsersContract
    {
        IQueryable<User> Get();
        User Get(string id);
        Task<User> Create(CreateUserModel model);
        Task<User> Update(string id, UpdateUserModel model);
        Task Delete(string id);
        Task ChangePassword(string id, ChangeUserPasswordModel model);
    }
}
