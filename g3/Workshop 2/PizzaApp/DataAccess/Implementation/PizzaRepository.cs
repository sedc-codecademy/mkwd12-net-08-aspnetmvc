using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaAppDbContext dbContext) : base(dbContext)
        {            
        }

        public List<Pizza> SearchByName(string name)
        {
            var items = _dbContext.Pizzas
                .Where(x => x.Name.Contains(name))
                .ToList();
            return items;
        }
    }
}
