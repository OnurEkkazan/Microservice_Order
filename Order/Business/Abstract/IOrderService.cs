using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        int Create(Order order);
        bool Update(Order order);
        bool Delete(string id);
        Order[] Get();
        Order[] GetOrderByUserId(string userId);
        Order GetOrderByOrderId(string orderId);
        bool ChangeStatus(string userId, string newStatus);
    }
}
