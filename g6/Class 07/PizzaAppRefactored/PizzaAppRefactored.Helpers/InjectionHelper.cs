using Microsoft.Extensions.DependencyInjection;
using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.DataAccess.Implementations;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Services.Implementations;
using PizzaAppRefactored.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Helpers
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
