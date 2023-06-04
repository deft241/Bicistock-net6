using System.Data;
using Microsoft.AspNetCore.Http;

namespace Bicistock.Common.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventDescription { get; set; }
        public string Event_Image { get; set; }
        public IFormFile Event_Image_upload { get; set; }
        public string BrandName { get; set; }
        public string MapURL { get; set; }


        public Event()
        {

        }

        public Event(DataRow fila)
        {
            Id = fila.Field<int>(0);
            EventDescription = fila.Field<string>(1);
            Event_Image = fila.Field<string>(2);
            BrandName = fila.Field<string>(3);
            MapURL = fila.Field<string>(4);
        }
    }


}
