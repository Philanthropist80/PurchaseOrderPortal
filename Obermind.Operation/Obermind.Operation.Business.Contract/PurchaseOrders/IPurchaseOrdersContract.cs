using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Data.Model.PurchaseOrders;

namespace Obermind.Operation.Business.Contract.PurchaseOrders
{
    public interface IPurchaseOrdersContract
    {
        IQueryable<PurchaseOrder> Get(string username);
        PurchaseOrder Get(string username, string id);
        Task<PurchaseOrder> Create(string username, CreatePurchaseOrderModel model);
        Task<PurchaseOrder> Update(string username, string id, UpdatePurchaseOrderModel model);
        Task Delete(string username, string id);
        
    }
}
