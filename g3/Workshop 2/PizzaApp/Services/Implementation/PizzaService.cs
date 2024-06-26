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
        private IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
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

        public void Create(PizzaViewModel pizzaModel)
        {
            if(_pizzaRepository.GetAll().Any(x => x.Name.ToLower() == pizzaModel.Name.ToLower()))
            {
                throw new Exception("Pizza with that name already exists");
            }

            var pizza = new Pizza()
            {
                Name = pizzaModel.Name,
                Description = pizzaModel.Description,
                ImageUrl = pizzaModel.ImageUrl
            };

            _pizzaRepository.Add(pizza);
        }

        public void Update(PizzaViewModel pizzaModel)
        {
            if (_pizzaRepository.GetAll().Any(x => x.Name.ToLower() == pizzaModel.Name.ToLower() && x.Id != pizzaModel.Id))
            {
                throw new Exception("Pizza with that name already exists");
            }

            var pizza = new Pizza()
            {
                Id =pizzaModel.Id,
                Name = pizzaModel.Name,
                Description = pizzaModel.Description,
                ImageUrl = pizzaModel.ImageUrl
            };

            _pizzaRepository.Update(pizza);
        }

        public void Delete(int id)
        {
            _pizzaRepository.DeleteById(id);
        }

        public List<PizzaViewModel> SearchByName(string name)
        {
            var pizzas = _pizzaRepository.SearchByName(name);
            return pizzas.Select(x => x.ToModel()).ToList();
        }
    }
}
