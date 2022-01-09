using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Data.Model.PurchaseOrders;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.Mapping.Agreements
{
    public class PurchaseOrderMap : Profile, IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<PurchaseOrder, PurchaseOrderModel>();
                map.ForMember(d => d.ListItems,opt => opt.MapFrom(src => src.ListItems));
        }
    }

    
}
