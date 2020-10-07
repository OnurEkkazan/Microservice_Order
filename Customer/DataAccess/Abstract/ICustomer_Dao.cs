using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomer_Dao : IEntityRepository<Customer>
    {
        bool Validate(string condation);
        bool CheckId(string id);
    }
}
