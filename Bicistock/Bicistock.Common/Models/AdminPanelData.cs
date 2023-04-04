namespace Bicistock.Common.Models
{
    public class AdminPanelData
    {
        public List<User> UserList = new List<User>();
        public Event Event { get; set; }
        public User UserEntity { get; set; }
        public List<Brand> BrandList { get; set; }
        public Component Component { get; set; }
        public Brand Brand { get; set; }
    }
}
