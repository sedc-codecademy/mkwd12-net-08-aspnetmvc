using Microsoft.EntityFrameworkCore;
using PizzaAppRefactored.Domain.Models;

namespace PizzaAppRefactored.DataAccess.EFImplementations
{
    public class PizzaEFRepository : IRepository<Pizza>
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public PizzaEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            var pizzaDb = _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizzaDb == null)
            {
                throw new Exception($"Pizza with id {id} was not found");
            }
            _pizzaAppDbContext.Pizzas.Remove(pizzaDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<Pizza> GetAll()
        {
            return _pizzaAppDbContext.Pizzas
                .Include(x => x.PizzaOrders) //joining Pizza with PizzaOrders
                .ThenInclude( x=> x.Order) //joining PizzaOrder with Order (pizza is not directly joined with order  - that's why we use theninclude)
                .ThenInclude(x => x.User) //joining Orders with User (pizza is not directly joined with user - that's why we use theninclude)
                .ToList();  
        }

        public Pizza GetById(int id)
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
           _pizzaAppDbContext.Pizzas.Add(entity);
           _pizzaAppDbContext.SaveChanges(); //here we call the db
            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            _pizzaAppDbContext.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }
    }
}
