using System.Data;
using Microsoft.AspNetCore.Http;

namespace Bicistock.Common.Models
{
    public class CS_Bici
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public string Image { get; set; }
        public IFormFile Image_upload { get; set; }
        public string BrandName { get; set; }


        public CS_Bici()
        {

        }

        public CS_Bici(DataRow fila)
        {
            Id = fila.Field<int>(0);
            Name = fila.Field<string>(1);
            Price = fila.Field<decimal>(2);
            BrandId = fila.Field<int>(3);
            Image = fila.Field<string>(4);
        }
    }
}
