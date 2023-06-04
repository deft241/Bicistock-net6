using Microsoft.AspNetCore.Http;
using System.Data;

namespace Bicistock.Common.Models
{
    public class Component
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public string Component_Image { get; set; }
        public IFormFile Component_Image_Upload { get; set; }

        public Component()
        {

        }

        public Component(DataRow fila)
        {
            id = fila.Field<int>(0);
            Name = fila.Field<string>(1);
            BrandName = fila.Field<string>(2);
            BrandId = fila.Field<int>(3);
            Component_Image = fila.Field<string>(4);
            Description = fila.Field<string>(5);
        }

    }
}
