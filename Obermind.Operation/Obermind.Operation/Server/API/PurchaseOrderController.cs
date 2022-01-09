using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Obermind.Operation.Business.Contract.PurchaseOrders;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Business.Model.Security;
using Obermind.Operation.Data.Access.Constants;
using Obermind.Operation.Data.Model.PurchaseOrders;
using Obermind.Operation.Data.Model.Security;
using Obermind.Operation.Server.Filters;
using Obermind.Operation.Server.Mapping.Contracts;

namespace Obermind.Operation.Server.API
{
    [EnableCors("AllowOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IPurchaseOrdersContract _purchaseOrderManager;
        private readonly IAutoMapper _mapper;

        public PurchaseOrderController(IHttpContextAccessor contextAccessor, IPurchaseOrdersContract purchaseOrderManager, IAutoMapper mapper)
        {
            _purchaseOrderManager = purchaseOrderManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        [QueryableResult]
        public IQueryable<PurchaseOrderModel> Get()
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var result = _purchaseOrderManager.Get(username);
            var models = _mapper.Map<PurchaseOrder, PurchaseOrderModel>(result);

            return models;
        }

        [HttpGet("{id}")]
        public PurchaseOrderModel Get(string id)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var item = _purchaseOrderManager.Get(username,id);
            var model = _mapper.Map<PurchaseOrderModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<PurchaseOrderModel> Post([FromBody] CreatePurchaseOrderModel requestModel)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var item = await _purchaseOrderManager.Create(username, requestModel);
            var model = _mapper.Map<PurchaseOrderModel>(item);
            return model;
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<PurchaseOrderModel> Put(string id, [FromBody] UpdatePurchaseOrderModel requestModel)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            var item = await _purchaseOrderManager.Update(username,id, requestModel);
            var model = _mapper.Map<PurchaseOrderModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var username = _contextAccessor.HttpContext.User.Identity.Name;
            await _purchaseOrderManager.Delete(username, id);
        }

    }
}
