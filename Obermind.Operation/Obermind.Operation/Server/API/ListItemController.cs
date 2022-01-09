using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Obermind.Operation.Business.Contract.PurchaseOrders;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Data.Model.PurchaseOrders;
using Obermind.Operation.Server.Filters;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.API
{
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ListItemController : ControllerBase
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IListItemsContract _listItemManager;
        private readonly IAutoMapper _mapper;

        public ListItemController(IHttpContextAccessor contextAccessor, IListItemsContract listItemManager, IAutoMapper mapper)
        {
            _listItemManager = listItemManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        [QueryableResult]
        public IQueryable<ListItemModel> Get()
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var result = _listItemManager.Get(username);
            var models = _mapper.Map<ListItem, ListItemModel>(result);

            return models;
        }

        [HttpGet("{id}")]
        public ListItemModel Get(string id)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var item = _listItemManager.Get(username, id);
            var model = _mapper.Map<ListItemModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ListItemModel> Post([FromBody] CreateListItemModel requestModel)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var item = await _listItemManager.Create(username, requestModel);
            var model = _mapper.Map<ListItemModel>(item);
            return model;
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<ListItemModel> Put(string id, [FromBody] UpdateListItemModel requestModel)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var item = await _listItemManager.Update(username,id, requestModel);
            var model = _mapper.Map<ListItemModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            await _listItemManager.Delete(username,id);
        }

    }
}
