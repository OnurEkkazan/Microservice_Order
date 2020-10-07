using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrder_Dao order_Dao;

        public OrderManager(IOrder_Dao order_Dao)
        {
            this.order_Dao = order_Dao;
        }

        public int Create(Order order)
        {
            if (this.order_Dao.CheckId(order.Id))
            {
                return -99;
            }
            order.CreatedAt = DateTime.Now.ToLocalTime();
            order.Id = String.IsNullOrEmpty(order.Id) ? Guid.NewGuid().ToString().Substring(0, 8) : order.Id;
            return this.order_Dao.Add(order);
        }

        public bool Delete(string id)
        {
            var state = this.order_Dao.Delete(id);
            if (state > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(Order order)
        {
            if (!this.order_Dao.CheckId(order.Id))
            {
                return false;
            }
            var oldRecord = this.order_Dao.Get(x => x.Id == order.Id);
            order.CreatedAt = oldRecord.CreatedAt;
            order.UpdatedAt = DateTime.Now.ToLocalTime();
            var state = this.order_Dao.Update(order);

            if (state > 0)
            {
                return true;
            }
            return false;
        }

        public Order[] Get()
        {
            return this.order_Dao.GetList().ToArray();
        }

        public Order GetOrderByOrderId(string orderId)
        {
            return this.order_Dao.Get(x => x.Id == orderId);
        }

        public Order[] GetOrderByUserId(string userId)
        {
            return this.order_Dao.GetList(x => x.CustomerId == userId).ToArray();
        }


        public bool ChangeStatus(string userId, string newStatus)
        {
            return this.order_Dao.ChangeStatus(userId, newStatus);
        }
    }
}
