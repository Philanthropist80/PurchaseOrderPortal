using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obermind.Operation.API.Common;
using Obermind.Operation.Business.Contract.PurchaseOrders;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Data.Access.DAL.Contracts;
using Obermind.Operation.Data.Model.PurchaseOrders;

namespace Obermind.Operation.Business.Manager.PurchaseOrders
{
    class ListItemsManager : IListItemsContract
    {
        private readonly IUnitOfWork _uow;
        private readonly IPurchaseOrdersContract _purchaseOrderManager;
        public ListItemsManager(IUnitOfWork uow, IPurchaseOrdersContract purchaseOrderManager)
        {
            _uow = uow;
            _purchaseOrderManager = purchaseOrderManager;
        }

        public IQueryable<ListItem> Get(string username)
        {
            var query = GetQuery(username)
                        .Where(x => !x.IsDeleted)
                        .OrderByDescending(x => x.CreatedAt);

            return query;
        }

        private IQueryable<ListItem> GetQuery(string username)
        {
            return _uow.Query<ListItem>();
        }

        public ListItem Get(string username, string id)
        {
            var li = GetQuery(username).FirstOrDefault(x => x.ItemId == id || x.Name == id);

            if (li == null)
            {
                throw new NotFoundException("List Item is not found");
            }

            return li;
        }

        public async Task<ListItem> Create(string username, CreateListItemModel model)
        {


            if (model == null)
            {
                throw new BadRequestException("List Item not provided");
            }

            if (string.IsNullOrWhiteSpace(model.POId))
            {
                throw new BadRequestException("Purchase Order is not linked");
            }

            /********** Get Purchase Order ********/
            var po = this._purchaseOrderManager.Get(username, model.POId);

            if (po == null)
            {
                throw new BadRequestException("Purchase Order is not exist");
            }

            /********** Total List Item Count Should Not Exceed 10 ********/
            if (po.ListItems.Count(x => !x.IsDeleted) == 10)
            {
                throw new BadRequestException("Purchase Order '" + po.Name + "' has already 10 list items. Please create a new purchase order for '" + model.Name + "'list item");
            }

            /********** Total PO Amount Should Not Exceed 10k ********/
            if ((po.ListItems.Where(x=>!x.IsDeleted).Sum(x => x.Amount) + model.Amount) > 10000)
            {
                throw new BadRequestException("Total List Item(s) amount should not exceed 10,000. Please review the amount.");
            }


            var poListItem = new ListItem()
            {
                Name = model.Name,
                Amount = model.Amount,
                POId = model.POId,
                CreatedAt = DateTime.Now
            };

            _uow.Add(poListItem);
            await _uow.CommitAsync();

            return poListItem;
        }
        public async Task<ListItem> Update(string username, string id, UpdateListItemModel model)
        {
            var li = GetQuery(username).FirstOrDefault(x => x.ItemId == id);

            if (li == null)
            {
                throw new NotFoundException("List Item is not found");
            }

            li.Name = model.Name;
            li.Amount = model.Amount;
            li.UpdatedAt = DateTime.Now;

            await _uow.CommitAsync();
            return li;
        }

        public async Task Delete(string username, string id)
        {
            var li = GetQuery(username).FirstOrDefault(u => u.ItemId == id);

            if (li == null)
            {
                throw new NotFoundException("List Item is not found");
            }


            // Return if LI already deleted.
            if (li.IsDeleted) return;

            // Delete List Item
            li.IsDeleted = true;
            li.UpdatedAt = DateTime.Now;


            await _uow.CommitAsync();
        }
    }
}
