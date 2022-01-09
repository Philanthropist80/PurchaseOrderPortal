using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Data.Model.PurchaseOrders;

namespace Obermind.Operation.Business.Contract.PurchaseOrders
{
    public interface IListItemsContract
    {
        IQueryable<ListItem> Get(string username);
        ListItem Get(string username,string id);
        Task<ListItem> Create(string username, CreateListItemModel model);
        Task<ListItem> Update(string username, string id, UpdateListItemModel model);
        Task Delete(string username, string id);

    }
}
