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
                ImageUrl = pizza.ImageUrl,
                PizzaTypeValue = (int) pizza.PizzaType,
                PizzaType = pizza.PizzaType.ToString()
            };

            return model;
        }

        public static PizzaViewModel ToShortModel(this Pizza pizza)
        {
            var model = new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name
            };

            return model;
        }

        public static Pizza ToDomainModel(this PizzaViewModel pizza)
        {
            var model = new Pizza
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
