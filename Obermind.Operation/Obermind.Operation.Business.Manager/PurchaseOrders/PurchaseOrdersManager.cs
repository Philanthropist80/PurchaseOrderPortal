using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.API.Common;
using Obermind.Operation.Business.Contract.PurchaseOrders;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Business.Model.PurchaseOrders;
using Obermind.Operation.Data.Access.DAL.Contracts;
using Obermind.Operation.Data.Model.PurchaseOrders;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Manager.PurchaseOrders
{
    public class PurchaseOrdersManager : IPurchaseOrdersContract
    {
        private readonly IUnitOfWork _uow;
        private readonly IUsersContract _userManager;
        public PurchaseOrdersManager(IUnitOfWork uow, IUsersContract userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }

        public IQueryable<PurchaseOrder> Get(string username)
        {
            var query = GetQuery(username).Where(x => !x.IsDeleted).OrderBy(x => x.Status).ThenByDescending(x => x.CreatedAt);

            return query;
        }

        private IQueryable<PurchaseOrder> GetQuery(string username)
        {

            /********** GET USER INFO ********************************/
            var loggedUser = this._userManager.Get(username);
            if (loggedUser == null)
            {
                throw new BadRequestException("Please re-login and try again.");
            }

            return _uow.Query<PurchaseOrder>().Where(x => x.UserId == loggedUser.Id)
                .Include(x => x.ListItems);
        }

        public PurchaseOrder Get(string username, string id)
        {
            var po = GetQuery(username).FirstOrDefault(x => x.POId == id || x.Name == id);

            if (po == null)
            {
                throw new NotFoundException("Purchase Order is not found");
            }

            return po;
        }

        public async Task<PurchaseOrder> Create(string username,  CreatePurchaseOrderModel model)
        {

            /********** At Least One List Item ***********************/
            if (model.ListItems == null)
            {
                throw new BadRequestException("Please add at least one list item to create a purchase orders");
            }
            
            /********** GET USER INFO ********************************/
            var loggedUser = this._userManager.Get(username);
            if (loggedUser == null)
            {
                throw new BadRequestException("Please re-login and try again.");
            }
            
            /********** GET PO COUNT ********************************/
            var TodaysPO = this.Get(username).Count(x => x.UserId == loggedUser.Id && x.CreatedAt == DateTime.Now);
            if (TodaysPO >= 10)
            {
                throw new BadRequestException("You have completed today's purchase orders quota.");
            }


            /********** PREPARE LIST OF LIST ITEMs *******************/
            var totalListAmount = 0.00M;
            List<ListItem> listItems = new List<ListItem>();
            foreach (var li in model.ListItems)
            {
                totalListAmount += li.Amount;
                var poListItem = new ListItem()
                {
                    Name = li.Name,
                    Amount = li.Amount,
                    CreatedAt = DateTime.Now,
                };

                listItems.Add(poListItem);
            }

            /********** Total PO Amount Should Not Exceed 10k ********/
            if (totalListAmount > 10000)
            {
                throw new BadRequestException("Total List Item(s) amount should not exceed 10,000. Please review the amount.");
            }

            var po = new PurchaseOrder()
            {
                Name = model.Name,
                Amount = totalListAmount,
                IsDeleted = false,
                Status = "DRAFT",
                ListItems = listItems,
                CreatedAt = DateTime.Now,
                UserId = loggedUser.Id
            };

            
            _uow.Add(po);
            await _uow.CommitAsync();

            return po;
        }
        public async Task<PurchaseOrder> Update(string username, string id, UpdatePurchaseOrderModel model)
        {
            var po = GetQuery(username).FirstOrDefault(x => x.POId == id);

            if (po == null)
            {
                throw new NotFoundException("Purchase Order is not found");
            }

            po.Name = model.Name;
            po.Status = model.Status;
            po.UpdatedAt = DateTime.Now;

            await _uow.CommitAsync();
            return po;
        }

        public async Task Delete(string username, string id)
        {
            var po = GetQuery(username).FirstOrDefault(u => u.POId == id);

            if (po == null)
            {
                throw new NotFoundException("Purchase Order is not found");
            }


            // Return if PO already deleted.
            if (po.IsDeleted) return;


            // Delete List Items
            foreach (var li in po.ListItems)
            {
                li.IsDeleted = true;
                li.UpdatedAt = DateTime.Now;
            }
            
            // Delete Purchase Order
            po.IsDeleted = true;
            po.UpdatedAt = DateTime.Now;


            await _uow.CommitAsync();
        }


    }
}
