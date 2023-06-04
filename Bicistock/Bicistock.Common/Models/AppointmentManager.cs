namespace Bicistock.Common.Models
{
    public class AppointmentManager
    {
        public List<Appointment> CitationList { get; set; }

        public User UserEntity = new User();
        public List<Brand> BrandList { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public string CurrentUser { get; set; }
        public DateTime Date { get; set; }
    }
}
