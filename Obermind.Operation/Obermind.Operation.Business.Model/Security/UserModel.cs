using System;
using System.Collections.Generic;
using System.Text;

namespace Obermind.Operation.Business.Model.Security
{
    public class UserModel
    {
        public UserModel()
        {
            Roles = new string[0];
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
