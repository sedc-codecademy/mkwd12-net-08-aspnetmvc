using DataAccess.Implementation;
using DataAccess.Interface;
using DomainModels;
using Mappers;
using Services.Interfaces;
using ViewModels;

namespace Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private PizzaRepository _pizzaRepository;

        public PizzaService()
        {
            _pizzaRepository = new PizzaRepository();
        }

        public List<PizzaViewModel> GetAll()
        {
            var pizzas = _pizzaRepository.GetAll();
            return pizzas.Select(x => x.ToModel()).ToList();
        }

        public PizzaViewModel GetDetails(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            return pizza.ToModel();
        }

        public void Create(PizzaViewModel pizza)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PizzaViewModel> SearchByName(string name)
        {
            var pizzas = _pizzaRepository.SearchByName(name);
            return pizzas.Select(x => x.ToModel()).ToList();
        }

        public void Update(PizzaViewModel pizza)
        {
            throw new NotImplementedException();
        }
    }
}
