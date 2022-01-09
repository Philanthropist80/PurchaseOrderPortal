using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Obermind.Operation.Business.Manager.Security;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.Mapping.Agreements
{
    public class UserTokenMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<UserToken, UserTokenModel>();
        }
    }
}
