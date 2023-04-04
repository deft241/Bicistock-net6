namespace Bicistock.Common.Models
{
    public class CS_ModeloCita
    {
        public List<CS_Cita> CitationList { get; set; }

        public CS_Usuario UserEntity = new CS_Usuario();
        public List<CS_Marca> BrandList { get; set; }
        public CS_Marca Brand { get; set; }
        public string Description { get; set; }
        public string CurrentUser { get; set; }
        public DateTime Date { get; set; }
    }
}
