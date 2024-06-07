namespace DomainModels
{
    public class Restaurant : BaseClass
    {
        public string Name { get; set; }
        public List<MenuItem> Menu { get; set; }
    }
}
