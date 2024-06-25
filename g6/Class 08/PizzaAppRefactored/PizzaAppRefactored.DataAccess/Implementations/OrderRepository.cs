using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            //validation
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }

            //Order order = GetById(id);
            //StaticDb.Orders.Remove(order);
            StaticDb.Orders.Remove(orderDb);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }
            return orderDb;
        }

        public int Insert(Order entity)
        {
            entity.Id = StaticDb.Orders.LastOrDefault().Id + 1;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order order = GetById(entity.Id);
            int index = StaticDb.Orders.FindIndex(x => x.Id == entity.Id);
            StaticDb.Orders[index] = entity;
        }
    }
}
