namespace Bicistock.Common.Models
{
    public class CS_ModeloGeneral
    {
        public List<CS_Bici> BikeList = new List<CS_Bici>();

        public List<CS_Componente> ComponentList = new List<CS_Componente>();

        public List<CS_Evento> EventList { get; set; }
        public CS_Bici BikeEntity { get; set; }
        public List<CS_Marca> BrandList { get; set; }
        public CS_Marca Brand { get; set; }

    }
}
