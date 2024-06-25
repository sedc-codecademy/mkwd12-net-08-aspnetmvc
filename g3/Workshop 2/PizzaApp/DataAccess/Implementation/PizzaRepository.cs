using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public List<Pizza> SearchByName(string name)
        {
            var pizzas = ReadContent();
            return pizzas.Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
