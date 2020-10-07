using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrder_Dao : IEntityRepository<Order>
    {
        bool ChangeStatus(string id, string newStatus);
        bool CheckId(string id);

    }
}
