using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFOrder : EntityRepositoryBase<Order, EFDBContext>, IOrder_Dao
    {
        public bool CheckId(string id)
        {
            using (var context = new EFDBContext())
            {
                var idState = context.Orders.SingleOrDefault(x => x.Id == id);
                if (idState != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool ChangeStatus(string id, string newStatus)
        {
            using (var context = new EFDBContext())
            {
                var changeStatusEntity = context.Orders.SingleOrDefault(x => x.Id == id);
                if (changeStatusEntity != null)
                {
                    changeStatusEntity.Status = newStatus;
                    context.Update(changeStatusEntity);
                    var state = context.SaveChanges();
                    return state > 0 ? true : false;
                }
                return false;
            }
        }
    }
}