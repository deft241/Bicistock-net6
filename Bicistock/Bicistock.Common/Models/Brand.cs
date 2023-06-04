using System.Data;

namespace Bicistock.Common.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Brand()
        {

        }

        public Brand(DataRow fila)
        {
            Id = fila.Field<int>("ID");
            Name = fila.Field<string>("NAME");
        }
    }
}
