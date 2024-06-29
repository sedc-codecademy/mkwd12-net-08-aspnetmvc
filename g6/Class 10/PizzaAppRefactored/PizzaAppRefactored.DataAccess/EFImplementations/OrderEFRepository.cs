using Microsoft.EntityFrameworkCore;
using PizzaAppRefactored.DataAccess.Implementations;
using PizzaAppRefactored.Domain.Models;

namespace PizzaAppRefactored.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public OrderEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext; 
        }
        public void DeleteById(int id)
        {
            //first find the order
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found");
            }
            //delete the order
            _pizzaAppDbContext.Orders.Remove(orderDb);
            _pizzaAppDbContext.SaveChanges(); //we need to call save changers to make the changes reflect in the db
        }

        public List<Order> GetAll()
        {
            //select * from Orders o
            //inner join User u
            //on u.Id = o.UserId
            //inner join PizzaOrders po
            //on po.OrderId = o.Id
            //inner join Pizzas p
            //on p.Id = po.Id
            var ordersDb = _pizzaAppDbContext.Orders
                .Include(x => x.User) //join with users
                .Include(x => x.PizzaOrders) //join Orders with PizzaOrders (the starting point is Orders)
                .ThenInclude(x => x.Pizza) //join PizzaOrders with Pizza (the starting point is PizzaOrders)
                .ToList();
            return ordersDb;
        }

        public Order GetById(int id)
        {
            Order orderDb = _pizzaAppDbContext.Orders
                 .Include(x => x.PizzaOrders)
                 .ThenInclude(x => x.Pizza)
                 .Include(x => x.User)
                 .FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found");
            }
            return orderDb;
        }

        public int Insert(Order entity)
        {
            _pizzaAppDbContext.Orders.Add(entity); //still no call to db
            _pizzaAppDbContext.SaveChanges(); //call to db
            return entity.Id;
        }

        public void Update(Order entity)
        {
            _pizzaAppDbContext.Update(entity); //still no call to db
            _pizzaAppDbContext.SaveChanges(); //call to db
        }
    }
}
