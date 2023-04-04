using System.Data;

namespace Bicistock.Common.Models
{
    public class CS_Cita
    {
        public int Id { get; set; }
        public DateTime DateCitation { get; set; }
        public DateTime DateRequest { get; set; }
        public string UserName { get; set; }
        public string CitationStatus { get; set; }
        public int BrandId { get; set; }
        public string CurrentUser { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }


        public CS_Cita()
        {

        }

        public CS_Cita(DataRow fila)
        {
            Id = fila.Field<int>(0);
            DateCitation = fila.Field<DateTime>(1);
            DateRequest = fila.Field<DateTime>(2);
            UserName = fila.Field<string>(3);
            CitationStatus = fila.Field<string>(4);
            BrandName = fila.Field<string>(5);
            Description = fila.Field<string>(6);
        }
    }


}
