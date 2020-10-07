using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        int Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(string id);
        Customer[] Get();
        Customer GetCustomerById(string id);
        bool Validate(string id);
    }
}
