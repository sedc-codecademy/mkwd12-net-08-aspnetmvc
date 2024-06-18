using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToModel(this Pizza pizza)
        {
            var model = new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                ImageUrl = pizza.ImageUrl
            };

            return model;
        }
    }
}
