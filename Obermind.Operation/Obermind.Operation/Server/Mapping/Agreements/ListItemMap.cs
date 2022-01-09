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
    public class ListItemMap : Profile, IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<ListItem, ListItemModel>(MemberList.None)
                .ForMember(dest => dest.ItemId,
                    opts => opts.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Amount,
                    opts => opts.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Name,
                    opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.POId,
                    opts => opts.MapFrom(src => src.POId))
                .ForMember(dest => dest.CreatedAt,
                    opts => opts.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt,
                    opts => opts.MapFrom(src => src.UpdatedAt));
        }

    }
}
