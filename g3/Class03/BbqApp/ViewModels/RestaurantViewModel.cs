namespace ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItemViewModel> Menu { get; set; }
    }
}
