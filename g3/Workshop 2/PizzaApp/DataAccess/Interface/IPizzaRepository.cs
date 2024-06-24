using DomainModels;

namespace DataAccess.Interface
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        List<Pizza> SearchByName(string name);
    }
}
