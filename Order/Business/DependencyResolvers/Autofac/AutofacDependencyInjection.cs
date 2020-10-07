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
    public class AutofacDependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFOrder>().As<IOrder_Dao>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
        }
    }
}
