namespace Bicistock.Common.Models
{
    public class InventoryManager
    {
        public List<Bike> BikeList = new List<Bike>();

        public List<Component> ComponentList = new List<Component>();

        public Component Component { get; set; }
        public List<Event> EventList { get; set; }
        public Bike BikeEntity { get; set; }
        public List<Brand> BrandList { get; set; }
        public Brand Brand { get; set; }

    }
}
