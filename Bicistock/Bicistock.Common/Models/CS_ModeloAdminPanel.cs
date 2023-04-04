namespace Bicistock.Common.Models
{
    public class CS_ModeloAdminPanel
    {
        public List<CS_Usuario> UserList = new List<CS_Usuario>();
        public CS_Evento Event { get; set; }
        public CS_Usuario UserEntity { get; set; }
        public List<CS_Marca> BrandList { get; set; }
        public CS_Componente Component { get; set; }
        public CS_Marca Brand { get; set; }
    }
}
