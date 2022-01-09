using Obermind.Operation.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Contract.Security
{
    public interface ILoginContract
    {
        IUserToken Authenticate(string username, string password);
        Task<User> Register(RegisterModel model);
        Task ChangePassword(string username, ChangeUserPasswordModel requestModel);
    }
}
