using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Mappers;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.PizzaViewModels;

namespace PizzaAppRefactored.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public List<PizzaOptionViewModel> GetAllPizzasForDropdown()
        {
            //call the repo
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();

            List<PizzaOptionViewModel> pizzaOptionViewModels = new List<PizzaOptionViewModel>();

            foreach(var pizza in pizzasDb)
            {
                var viewModel = PizzaMapper.ToPizzaOptionsViewModel(pizza);
                pizzaOptionViewModels.Add(viewModel);
            }

            return pizzaOptionViewModels;
        }
    }
}
