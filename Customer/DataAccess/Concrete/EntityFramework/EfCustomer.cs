using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomer : EfEntityRepositoryBase<Customer, EFDBContext>, ICustomer_Dao
    {
        public bool CheckId(string id)
        {
            using (var context = new EFDBContext())
            {
                var idState = context.Customers.SingleOrDefault(x => x.Id == id);
                if (idState != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Validate(string condation)
        {
            throw new NotImplementedException();
        }
    }
}
