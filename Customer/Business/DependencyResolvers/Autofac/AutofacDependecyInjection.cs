using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacDependecyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCustomer>().As<ICustomer_Dao>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
        }
    }
}
