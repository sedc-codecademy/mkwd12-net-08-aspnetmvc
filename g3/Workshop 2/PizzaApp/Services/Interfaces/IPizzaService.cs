using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Services.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetAll();
        PizzaViewModel GetDetails(int id);
        void Create(PizzaViewModel pizza);
        void Update(PizzaViewModel pizza);
        void Delete(int id);
        List<PizzaViewModel> SearchByName(string name);
        List<SelectListItem> GetTypeOptions();
    }
}
