using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Model.Security;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.Mapping.Agreements
{
    public class UserMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<User, UserModel>();
            map.ForMember(x => x.Roles, x => x.MapFrom(u => u.Roles.Select(r => r.Role.Name).ToArray()));
        }
    }
}
