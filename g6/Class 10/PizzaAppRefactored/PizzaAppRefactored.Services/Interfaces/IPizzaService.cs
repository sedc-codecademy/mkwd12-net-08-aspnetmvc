using PizzaAppRefactored.ViewModels.PizzaViewModels;

namespace PizzaAppRefactored.Services.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaOptionViewModel> GetAllPizzasForDropdown();
    }
}
