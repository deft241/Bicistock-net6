using System.Data;
using Microsoft.AspNetCore.Http;

namespace Bicistock.Common.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Image { get; set; }
        public IFormFile? Image_upload { get; set; }
        public string? BrandName { get; set; }


        public Bike()
        {

        }

        public Bike(DataRow fila)
        {
            Id = fila.Field<int>(0);
            Name = fila.Field<string>(1);
            BrandId = fila.Field<int>(2);
            Image = fila.Field<string>(3);
        }
    }
}
