using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomer_Dao customer_Dao;

        public CustomerManager(ICustomer_Dao customer_Dao)
        {
            this.customer_Dao = customer_Dao;
        }

        public int Create(Customer customer)
        {
            if (this.customer_Dao.CheckId(customer.Id))
            {
                return -99;
            }
            customer.CreatedAt = DateTime.Now.ToLocalTime();
            customer.Id = String.IsNullOrEmpty(customer.Id) ? Guid.NewGuid().ToString().Substring(0, 8) : customer.Id;
            return this.customer_Dao.Add(customer);
        }

        public bool Delete(string id)
        {
            var state = this.customer_Dao.Delete(id);
            if (state > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(Customer customer)
        {
            if (!this.customer_Dao.CheckId(customer.Id))
            {
                return false;
            }
            customer.UpdatedAt = DateTime.Now.ToLocalTime();
            var oldRecord = this.customer_Dao.Get(x => x.Id == customer.Id);
            customer.CreatedAt = oldRecord.CreatedAt;
            var state = this.customer_Dao.Update(customer);

            if (state > 0)
            {
                return true;
            }
            return false;
        }

        public Customer[] Get()
        {
            return this.customer_Dao.GetList().ToArray();
        }

        public Customer GetCustomerById(string id)
        {
            return this.customer_Dao.Get(x => x.Id == id);
        }

        public bool Validate(string id)
        {
            throw new NotImplementedException();
        }
    }
}
